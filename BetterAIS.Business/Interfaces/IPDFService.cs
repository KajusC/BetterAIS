namespace BetterAIS.Business.Interfaces;

public interface IPDFService
{
    Task CreatePDF(string vidko, string path);
}