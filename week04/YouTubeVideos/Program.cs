using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Fundamentals: Abstraction", "Tech Educator", 450);
        video1.AddComment(new Comment("Ana", "¡Excelente explicación del concepto!"));
        video1.AddComment(new Comment("Carlos", "Me ayudó mucho con mi tarea."));
        video1.AddComment(new Comment("Luis", "¿Harás un video sobre encapsulamiento?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Building Desktop Apps with .NET", "Code Master", 1200);
        video2.AddComment(new Comment("María", "Muy completo, gracias."));
        video2.AddComment(new Comment("Jorge", "Me perdí en el minuto 15."));
        video2.AddComment(new Comment("Elena", "Esperando la segunda parte."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Top 10 VS Code Extensions", "DevOps Guy", 600);
        video3.AddComment(new Comment("Pedro", "Instalé la mitad de las extensiones, muy útiles."));
        video3.AddComment(new Comment("Sofía", "Cursor también es una gran alternativa."));
        video3.AddComment(new Comment("Diego", "Faltó mencionar GitLens."));
        video3.AddComment(new Comment("Laura", "Buen resumen."));
        videos.Add(video3);

        // Iteración y visualización
        foreach (Video v in videos)
        {
            Console.WriteLine($"\nTítulo: {v.Title}");
            Console.WriteLine($"Autor: {v.Author}");
            Console.WriteLine($"Duración: {v.LengthInSeconds} segundos");
            Console.WriteLine($"Número de comentarios: {v.GetCommentCount()}");

            foreach (Comment c in v.GetComments())
            {
                Console.WriteLine($"- {c.Name}: {c.Text}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
