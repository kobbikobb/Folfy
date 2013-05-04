using System.Collections.Generic;
using Folfy.WebApi.Models;

namespace Folfy.WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Folfy.WebApi.Data.FolfyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private Course CreateCourse(string name, int number)
        {
            var course = new Course
            {
                Name = name,
                Holes = new List<CourseHole>()
            };

            for (int i = 1; i <= number; i++)
            {
                course.Holes.Add(new CourseHole { Number = i, Par = 3 });
            }

            return course;
        }

        private Scorecard CreateScorecard(User user, int number)
        {
            var scorecard = new Scorecard
            {
                Owner = user,
                Holes = new List<Hole>()
            };

            for (int i = 1; i <= number; i++)
            {
                scorecard.Holes.Add(new Hole {Number = i, Player = user, Score = 2 });
            }

            return scorecard;
        }

        protected override void Seed(Folfy.WebApi.Data.FolfyDbContext context)
        {
            var course1 = CreateCourse("Klambratún", 9);
            var course2 = CreateCourse("Gufunes", 18);

            if(!context.Courses.Any(x=>x.Name == course1.Name))
                context.Courses.Add(course1);

            if (!context.Courses.Any(x => x.Name == course2.Name))
                context.Courses.Add(course2);

            var user1 = new User
                {
                    Name = "Frank Johnsson", 
                    Password = "Abc123", 
                    Email = "hollywoood@mail.com"
                };

            var user2 = new User
            {
                Name = "Lenny Kravitz",
                Password = "ForU",
                Email = "lenny@mail.com"
            };

            if (!context.Users.Any(x => x.Name == user1.Name))
                context.Users.Add(user1);

            if (!context.Users.Any(x => x.Name == user2.Name))
                context.Users.Add(user2);

            var scorecard1 = CreateScorecard(user1, 9);
            var scorecard2 = CreateScorecard(user2, 28);

            context.Scorecards.Add(scorecard1);
            context.Scorecards.Add(scorecard2);
        }
    }
}
