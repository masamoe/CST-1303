using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.LangReview
{
    public interface ILanguageInterpreter
    {
        bool IsInitialized { get; }

        void Initialize();

        void Interpret(string text);
    }
}
