using Microsoft.EntityFrameworkCore.Metadata;
using OldSchoolDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolAplication.Dto
{
    public class PostDto
    {
        public static PostDomain CommandAddToDomain(string[] commands, int userId)
        {
            return new PostDomain()
            {
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
                UserId = userId,
                Content = commands.Length > 3 ? commands[3] : null,
                ASCII = commands.Length > 5 ? commands[5] : null,
                KeyWords = commands.Length > 7 ? commands[7] : null,
                Likes = 0,
                Links = commands.Length > 9 ? commands[9] : null,
            };
        }
        public static int[] CommandReadToDomain(string[] commands)
        {
            var result = new List<int>();

            foreach (var command in commands.Skip(3))
            {
                if (command.Contains("..."))
                {
                    // Divide a string para obter os dois números do range
                    var numbers = command.Split(new[] { "..." }, StringSplitOptions.None);
                    int start = int.Parse(numbers[0]);
                    int end = int.Parse(numbers[1]);

                    // Adiciona a sequência de números do range à lista de resultados
                    result.AddRange(Enumerable.Range(start, end - start + 1));
                }
                else
                {
                    // Adiciona o número convertido à lista de resultados
                    result.Add(int.Parse(command));
                }
            }

            // Retorna a lista de números como um array
            return result.ToArray();
        }

        public static int GetPostIdToUpdate(string[] commands)
        {
            return int.Parse(commands[3]);
        }

        public static PostDomain CommandUpdateToDomain(PostDomain post, string[] commands)
        {
            post.Content = commands[5];
            post.ASCII = commands.Length >=7 ? commands[6] : post.ASCII;
            post.KeyWords = commands.Length >= 9 ? commands[8] : post.KeyWords;
            post.Links = commands.Length >= 11 ? commands[8] : post.Links;
            post.UpdatedAt = DateTime.Now;
            return post;
        }
        public static int[] CommandDeleteToDomain(string[]commands)
        {
            return commands.Skip(3).Select(int.Parse).ToArray();
        }

        public static int[] CommandLikeToId(string[] commands)
        {
            return commands.Skip(3).Select(int.Parse).ToArray();
        }
    }
}
