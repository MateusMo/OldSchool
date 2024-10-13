using OldSchoolDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolAplication.Dto
{
    public class UserDto
    {
        public static UserDomain CommandAddToDomain(string[] command)
        {
            return new UserDomain()
            {
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
                LastLogin = DateTime.Now,
                Nickname = command[3],
                PasswordHash = command[5]
            };
        }
        public static int[] CommandReadToDomain(string[] command)
        {
            // Verifica se existe um comando com "..." no array
            if (command.Any(x => x.Contains("...")))
            {
                // Encontra a string que contém "..."
                var range = command.First(x => x.Contains("..."));

                // Divide a string para obter os dois números do range
                var numbers = range.Split(new[] { "..." }, StringSplitOptions.None);
                int start = int.Parse(numbers[0]);
                int end = int.Parse(numbers[1]);

                // Gera uma lista de inteiros do primeiro até o último número do range
                var rangeNumbers = Enumerable.Range(start, end - start + 1).ToArray();

                // Retorna a lista de números do range
                return rangeNumbers;
            }

            // Caso não tenha "..." no comando, retorna os valores restantes após o terceiro
            return command.Skip(3).Select(int.Parse).ToArray();
        }

        public static UserDomain CommandUpdateToDomain(UserDomain user, string[] command)
        {
            user.PasswordHash = command[5];
            user.Nickname = command[3];
            user.UpdatedAt = DateTime.Now;
            return user;
        }
    }
}
