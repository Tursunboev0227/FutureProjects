using AutoMapper;
using DOT.DOMEN.Entities.DTOS;
using DOT.DOMEN.Entities.Models;
using FutureProjects.API.Controllers;
using FutureProjects.Application.Abstractions.IServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureProjectsTest.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserService> _userservice = new Mock<IUserService>();
        MapperConfiguration? mockMapepr = new MapperConfiguration(conf =>
        {
            conf.AddProfile(new AutoMapperProfile());
        });

        public static IEnumerable<object[]> GetUserFromDataGenerator()
        {
            yield return new object[]
            {
                new UserDTO()
                {
                    Name = "Test Product 1",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                },
                new User()
                {
                    Name = "Test Product 34",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                }
            };

            yield return new object[]
            {
                new UserDTO()
                {
                    Name = "Test Product 2",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                },
                new User()
                {
                    Name = "Test Product 2",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                }
            };

           
        }

        // Create User Test
        [Theory]
        [MemberData(nameof(GetUserFromDataGenerator), MemberType = typeof(UserServiceTests))]
        public async void Create_User_Test(UserDTO inputUser, User expextedUser)
        {
            var myMapper = mockMapepr.CreateMapper();


            var result = myMapper.Map<User>(inputUser);
            // logic
            _userservice.Setup(x => x.CreateAsync(It.IsAny<UserDTO>()))
            .ReturnsAsync(result);

            var controller = new UsersController(_userservice.Object);


            // Act
            var createdUser = await controller.CreateUser(inputUser);

            // Assert
            Assert.NotNull(createdUser); // Verify a user object is returned

            Assert.True(CompareModels(expextedUser, createdUser));
            Assert.True(CompareModels(expextedUser, createdUser));
        }

        public static bool CompareModels(User inputUser, User user)
        {
            if (inputUser.Name == user.Name && inputUser.Email == user.Email && inputUser.Password == user.Password
                && inputUser.Login == user.Login)
            {
                return true;
            }

            return false;
        }


        // Get User Test
        [Fact]
        public async Task Get_User_ById_TestAsync()
        {
            // Arrange
            var user = new User()
            {
                Id = 1,
                Name = "User1",
                Email = "tursunboev@gmail.com",
                Password = "123",
                Login = "tes123",
            };

            _userservice.Setup(s => s.GetById(5)).ReturnsAsync(user);

            var controller = new UsersController(_userservice.Object);

            // Act
            var result = await controller.UserGetById(1);

            //// Assert
            //var okResult = Assert.IsType<OkObjectResult>(result);

            //var returnUser = Assert.IsType<User>(okResult.Value);

            Assert.True(CompareModels(result, user));
        }

        // Update
        [Fact]
        public async void Update_User_Test()
        {
            var _mapper = mockMapepr.CreateMapper();
            // Arrange
            int Id = 5;
            var user = new UserDTO()
            {
                Name = "Asliddin",
                Email = "asliddin3@gmail.com",
                Password = "123",
                Login = "123ww",
            };

            var result = _mapper.Map<User>(user);

            _userservice.Setup(x => x.UpdateAsync(Id, user))
                .ReturnsAsync(result);

            var controller = new UsersController(_userservice.Object);

            var natija = await controller.UpdateUser(Id, user);



            Assert.True(CompareModels(natija, result));

        }
        [Fact]
        public async void Delete_User_Test()
        {
            // Arrange
            int userIdToDelete = 1;

            // Setup UserService mock
            _userservice.Setup(x => x.DeleteAsync(1))
                            .ReturnsAsync(true); 

            var controller = new UsersController(_userServiceMock.Object);

            // Act
            var result = await controller.DeleteAsync(userIdToDelete);

            // Assert
            Assert.True(result);



    }
}
