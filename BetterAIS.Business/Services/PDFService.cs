using System.Net.Mime;
using AutoMapper;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BetterAIS.Business.Services;

public class PDFService : IPDFService
{
    private readonly IStudentaiService _studentaiService;
    private readonly IMapper _mapper;
    private readonly IDocumentContainer _document;

    public PDFService(IStudentaiService studentaiService, IMapper mapper)
    {
        _studentaiService = studentaiService;
        _mapper = mapper;
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public async Task CreatePDF(string vidko, string path)
    {
        var student = await _studentaiService.GetByIdAsync(vidko);

        Document.Create(container =>
        {
            CreateCanvas(container);

            container.Page(page =>
            {
                page.Margin(50);

                page.Header().Element(CreateHeader);
            });

        }).GeneratePdfAndShow();

    }

    private void CreateCanvas(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Margin(50);

                page.Header().Height(100).Background(Colors.Grey.Lighten1);
                page.Content().Background(Colors.Grey.Lighten3);
                page.Footer().Height(50).Background(Colors.Grey.Lighten1);
            });
    }

    private void CreateHeader(IContainer container)
    {
        container
            .Row(row =>
            {
                row.RelativeItem().Column(stack =>
                {
                    stack.Item().Text("Studento informacija").AlignCenter().FontSize(20);
                    stack.Item().Text("Vardas: " + "vardas").FontSize(15);
                    stack.Item().Text("Pavardė: " + "pavardė").FontSize(15);
                    stack.Item().Text("Vidko: " + "vidko").FontSize(15);
                    stack.Item().Text("El. paštas: " + "el. paštas").FontSize(15);
                    stack.Item().Text("Telefonas: " + "telefonas").FontSize(15);
                });
            });

    }
}