using System.Net.Mime;
using AutoMapper;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Elements;
using Microsoft.Extensions.Hosting.Internal;

namespace BetterAIS.Business.Services
{
    public class PDFService : IPDFService
    {
        private readonly IStudentaiService _studentaiService;
        private readonly ISuvestinesService _suvestinesService;
        private readonly IFinansavimoTipaiService _finansavimoTipaiService;
        private readonly IUzsiemimoTipaiService _uzsiemimoTipaiService;
        private readonly IStudijuProgramaService _studijuProgramaService;
        private readonly IStudentoStatusaiRepository _studentoStatusaiRepository;
        private readonly IMoksliniaiLaipsniaiRepository _moksliniaiLaipsniaiRepository;
        private readonly IDestytojaiService _destytojaiService;
        private readonly IPaskaitosService _paskaitosService;
        private readonly IFakultetaiService _fakultetaiService;
        private readonly IModuliaiService _moduliaiService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;

        public PDFService(IStudentaiService studentaiService,
            ISuvestinesService suvestinesService,
            IFinansavimoTipaiService finansavimoTipaiService,
            IUzsiemimoTipaiService uzsiemimoTipaiService,
            IStudijuProgramaService studijuProgramaService,
            IStudentoStatusaiRepository statusaiRepository,
            IMoksliniaiLaipsniaiRepository moksliniaiLaipsniaiRepository,
            IDestytojaiService destytojaiService,
            IPaskaitosService paskaitosService,
            IFakultetaiService fakultetaiService,
            IModuliaiService moduliaiService,
            IWebHostEnvironment hostingEnvironment,
            IMapper mapper)
        {
            _studentaiService = studentaiService;
            _suvestinesService = suvestinesService;
            _finansavimoTipaiService = finansavimoTipaiService;
            _uzsiemimoTipaiService = uzsiemimoTipaiService;
            _studijuProgramaService = studijuProgramaService;
            _studentoStatusaiRepository = statusaiRepository;
            _moksliniaiLaipsniaiRepository = moksliniaiLaipsniaiRepository;
            _destytojaiService = destytojaiService;
            _paskaitosService = paskaitosService;
            _fakultetaiService = fakultetaiService;
            _moduliaiService = moduliaiService;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public async Task CreatePDF(string vidko, string path)
        {
            // Fetch data asynchronously beforehand
            var student = await _studentaiService.GetByIdAsync(vidko);
            var suvestines = await _suvestinesService.GetSuvestinesByVidko(vidko);
            var finansavimoTipas = await _finansavimoTipaiService.GetByIdAsync(student.Finansavimas);
            var studentoStatusas = await _studentoStatusaiRepository.GetByIdAsync(student.Statusas);
            var studijuPrograma = await _studijuProgramaService.GetByIdAsync(student.FkProgramosKodas);
            var mokslinisLaipsnis = await _moksliniaiLaipsniaiRepository.GetByIdAsync(studijuPrograma.MokslinisLaipsnis);

            string logoPath = Path.Combine(_hostingEnvironment.WebRootPath, "aislogo.webp");

            // Synchronously build the PDF
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    // Set overall page margins
                    page.Margin(40);

                    // Professional University Header
                    page.Header().Element(header =>
                    {
                        header.AlignCenter().Column(col =>
                        {
                            col.Spacing(5);
                            col.Item().Text("Kaunas University of Technology BetterAIS").FontSize(22).Bold();
                            col.Item().Text("Studento suvestinė").FontSize(14).Italic().FontColor(Colors.Grey.Darken1);
                        });
                    });

                    // Main Content Area
                    page.Content().Element(content =>
                    {
                        content.Column(col =>
                        {
                            col.Spacing(30);

                            // Add a border and background to highlight the student section
                            col.Item().Border(1).BorderColor(Colors.Grey.Lighten2).Padding(15).Background(Colors.Grey.Lighten5)
                                .Element(headerContainer => CreateHeader(headerContainer, student));

                            // Academic and Program Info
                            col.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Element(infoContainer =>
                                CreateContent(infoContainer, student, finansavimoTipas, studentoStatusas, studijuPrograma, mokslinisLaipsnis)
                            );

                            // Suvestine Table with a professional style
                            col.Item().PaddingTop(15).Text("Suvestinės Duomenys").FontSize(18).Bold().Underline();
                            col.Item().Element(tableContainer =>
                                CreateSuvestineTable(tableContainer, suvestines)
                            );
                        });
                    });

                    // Professional Footer
                    page.Footer().Element(footer =>
                    {
                        footer.AlignCenter().Text(text =>
                        {
                            text.Span("Kaunas University of Technology | Generated by BetterAIS").FontSize(10).FontColor(Colors.Grey.Darken1);
                            text.Span(" | ");
                            text.Span(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).FontSize(10).FontColor(Colors.Grey.Darken1);
                        });
                    });
                });
            }).GeneratePdf(path + $"{vidko}_ataskaita.pdf");
        }


        private void CreateHeader(IContainer container, StudentaiDTO studentai)
        {
            container
                .Row(row =>
                {
                    row.RelativeItem().Column(stack =>
                    {
                        stack.Item().Text("Studento Informacija").AlignCenter().FontSize(20).Bold();
                        stack.Item().Text($"Name: {studentai.Vardas} {studentai.Pavarde}").FontSize(15);
                        stack.Item().Text($"VIDKO: {studentai.Vidko}").FontSize(15);
                        stack.Item().Text($"Email: {studentai.ElPastas}").FontSize(15);
                        stack.Item().Text($"Phone: {studentai.TelefonoNr}").FontSize(15);
                    });
                });
        }

        private void CreateContent(
            IContainer container,
            StudentaiDTO studentai,
            FinansavimoTipaiDTO finansavimoTipas,
            StudentoStatusai studentoStatusas,
            StudijuProgramaDTO studijuPrograma,
            MoksliniaiLaipsniai mokslinisLaipsnis)
        {
            container
                .Column(column =>
                {
                    column.Spacing(20);

                    column.Item().Text("Academinė Informacija").FontSize(18).Bold();
                    column.Item().Text($"Studijų pradžios metai: {studentai.StudijuPradzia.ToShortDateString()}").FontSize(15);
                    column.Item().Text($"Statusas: {studentoStatusas.Name}").FontSize(15);
                    column.Item().Text($"Finansavimas: {finansavimoTipas.Name}").FontSize(15);
                    column.Item().Text($"Programos kodas: {studentai.FkProgramosKodas}").FontSize(15);

                    column.Item().Text("Studijų Programa").FontSize(18).Bold();
                    column.Item().Text($"Pavadinimas: {studijuPrograma.Pavadinimas}").FontSize(15);
                    column.Item().Text($"Kodas: {studijuPrograma.ProgramosKodas}").FontSize(15);
                    column.Item().Text($"Įgyjama kvalifikacija: {mokslinisLaipsnis.Name}").FontSize(15);
                    column.Item().Text($"Kreditai: {studijuPrograma.KredituKiekis}").FontSize(15);
                });
        }


        private void CreateSuvestineTable(IContainer container, IEnumerable<Suvestine> suvestines)
        {
            container.Column(column =>
            {
                column.Item().Table(table =>
                {
                    // Define columns
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(70); // Užduotis
                        columns.ConstantColumn(50);  // Dalyvavo
                        columns.ConstantColumn(70);  // Tipas
                        columns.ConstantColumn(90);  // Paskaitos Pavadinimas
                        columns.ConstantColumn(70);  // Paskaitos Data
                        columns.ConstantColumn(50);  // Privalomumas
                        columns.ConstantColumn(70); // Dėstytojas
                    });

                    // Table Header
                    table.Header(header =>
                    {
                        string[] headers = { "Užduotis", "Dalyvavo", "Tipas", "Paskaitos Pavadinimas", "Paskaitos Data", "Privalomumas", "Dėstytojas" };

                        foreach (var text in headers)
                        {
                            header.Cell().Element(cell =>
                            {
                                cell.BorderBottom(1).BorderColor(Colors.Black).Padding(3).AlignCenter()
                                    .Text(text).FontSize(7).Bold();
                            });
                        }
                    });

                    // Table Body
                    foreach (var (s, index) in suvestines.Select((value, i) => (value, i)))
                    {
                        var uzduotis = s.FkIdUzduotisNavigation;
                        string dalyvavoText = s.Dalyvavo ? "Taip" : "Ne";

                        string uzduotisPavadinimas = uzduotis?.Pavadinimas ?? "N/A";
                        string tipas = uzduotis?.TipasNavigation?.Name ?? "N/A";
                        string paskaitosDestytojoVardas = s.FkIdPaskaitaNavigation?.FkDestytojasVidkoNavigation.VidkoNavigation.Vardas ?? "N/A";
                        string paskaitosDestytojoPavarde = s.FkIdPaskaitaNavigation?.FkDestytojasVidkoNavigation.VidkoNavigation.Pavarde ?? "N/A";

                        string paskaitosPavadinimas = s.FkIdPaskaitaNavigation?.FkModulisKodasNavigation?.Pavadinimas ?? "N/A";
                        string paskaitosData = s.FkIdPaskaitaNavigation?.Data.ToString("yyyy-MM-dd") ?? "N/A";
                        string paskaitosPrivalomumas = s.FkIdPaskaitaNavigation.Privalomas ? "Taip" : "Ne";

                        // Alternate row colors for better readability
                        var backgroundColor = index % 2 == 0 ? Colors.White : Colors.Grey.Lighten5;

                        string[] rowValues = { uzduotisPavadinimas, dalyvavoText, tipas, paskaitosPavadinimas, paskaitosData, paskaitosPrivalomumas, $"{paskaitosDestytojoVardas} {paskaitosDestytojoPavarde}" };

                        foreach (var value in rowValues)
                        {
                            table.Cell().Element(cell =>
                            {
                                cell.Background(backgroundColor).Padding(3).AlignLeft()
                                    .Text(value).FontSize(7);
                            });
                        }
                    }
                });
            });
        }

        private void CreateFooter(IContainer container)
        {
            container
                .AlignCenter()
                .Text(text =>
                {
                    text.Span("Generated by BetterAIS").FontSize(12);
                    text.Span(" | ");
                    text.Span(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).FontSize(12);
                });
        }
    }
}
