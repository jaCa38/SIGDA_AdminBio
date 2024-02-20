using System;
using System.Reflection;

namespace SIGDA_BackEnd.Reporteador.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}