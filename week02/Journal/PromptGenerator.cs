using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "¿Qué fue lo mejor de mi día?",
        "¿Cómo vi la mano del Señor hoy?",
        "¿Qué aprendí hoy?",
        "¿A quién pude ayudar hoy?",
        "¿Por qué estoy agradecido hoy?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
