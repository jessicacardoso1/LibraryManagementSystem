﻿            using LibraryManagementSystem.Application.Models;
            using LibraryManagementSystem.Core.Entities;
            using MediatR;

            namespace LibraryManagementSystem.Application.Commands.UserCommands.InsertUser
            {
                public class InsertUserCommand : IRequest<ResultViewModel<int>>
                {
                    public string Nome { get; set; }
                    public string Email { get; set; }
                    public DateTime BirthDate { get; set; }
                    public UserType UserType { get; set; }
                    public string Password { get; set; }

                    public string Role { get; set; }


                    public User ToEntity()
                        => new(Nome, Email, BirthDate, UserType, Password, Role);

                    public void SetHashedPassword(string password)
                    {
                        Password = password;
                    }

                }
            }
