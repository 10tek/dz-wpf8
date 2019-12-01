using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.EnsureCreated();
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-TALUG4B\SQLEXPRESS;Database=GameAd;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dota2 = new Game
            {
                Name = "Dota 2",
                Genre = "Стратегии, MOBA",
                IssueYear = "9 июля 2013",
                Price = "Free to Play",
                Description = "Dota 2 — компьютерная многопользовательская командная игра в жанре multiplayer online battle arena, разработанная корпорацией Valve. Игра является продолжением DotA — пользовательской карты-модификации для игры Warcraft III: Reign of Chaos и дополнения к ней Warcraft III: The Frozen Throne. Игра изображает сражение на карте особого вида; в каждом матче участвуют две команды по пять игроков, управляющих «героями» — персонажами с различными наборами способностей. Для победы в матче команда должна уничтожить особый объект-«крепость», принадлежащий вражеской стороне, и защитить от уничтожения собственную «крепость»."
            };

            var w3 = new Game
            {
                Name = "Warcraft III The Frozen Throne",
                Genre = "Стратегии, MOBA",
                IssueYear = "1 июля 2003",
                Price = "1300 рублей",
                Description = "Warcraft III: The Frozen Throne (от англ. warcraft — военное ремесло, frozen throne — ледяной трон) — официальное дополнение к компьютерной игре в жанре стратегии в реальном времени 2002 года Warcraft III: Reign of Chaos.События дополнения продолжают сюжет Warcraft III: Reign of Chaos. После битвы на горе Хиджал расы Азерота стали возвращаться к мирной жизни. Однако последствия Третьей Войны порождают новые конфликты. Как и в предыдущей части, сюжетная линия представлена в виде кампаний, которые образуют общий сюжет. Каждая кампания состоит из глав."
            };

            var nfs = new Game
            {
                Name = "Need For Speed: Most Wanted",
                Genre = "Аркада, Автогонки",
                IssueYear = "15 ноября 2005",
                Price = "123 рублей",
                Description = "Need for Speed: Most Wanted (рус. Жажда скорости: Самый разыскиваемый; сокр. NFSMW) — компьютерная игра серии Need for Speed в жанре аркадной автогонки, разработанная студией EA Canada и изданная компанией Electronic Arts для консолей, персональных компьютеров и мобильных телефонов в 2005 году. Действия игры происходят в вымышленном городе Рокпорт, в котором игроку предоставлена свобода передвижения. По сюжету главный герой выигрывает гонки и продвигается вверх по «Чёрному списку» гонщиков, чтобы вернуть свой автомобиль BMW M3 GTR, отвоёванный Рэйзором обманным путём."
            };

            modelBuilder.Entity<Game>().HasData(dota2, w3, nfs);
            modelBuilder.Entity<Image>().HasData(
                new Image { GameId = nfs.Id, Url = "https://www.nfscars.net/media/showroom/rides/images/2016/05/16/f5669b14-82ef-4696-a46c-0746c82e0317.jpg" },
                new Image { GameId = nfs.Id, Url = "https://i.ytimg.com/vi/JrXmdGOXHL0/maxresdefault.jpg" },
                new Image { GameId = nfs.Id, Url = "https://u.kanobu.ru/screenshots/6/becb7f4a-0460-4ab0-8440-c05b7d0a2c1a.jpg" },
                new Image { GameId = nfs.Id, Url = "https://i.playground.ru/i/file/143209/content/0vig1udj.jpg" },
                new Image { GameId = w3.Id, Url = "https://i.ytimg.com/vi/YsGOeD6zuyg/maxresdefault.jpg" },
                new Image { GameId = w3.Id, Url = "https://i.ytimg.com/vi/WfJkYRrTUOc/maxresdefault.jpg" },
                new Image { GameId = w3.Id, Url = "https://www.hiveworkshop.com/media/6.117987/full" },
                new Image { GameId = dota2.Id, Url = "https://games.mail.ru/pic/pc/gallery/22/d4/2f7c4590.jpeg" },
                new Image { GameId = dota2.Id, Url = "https://i.ytimg.com/vi/3AyzNtvgXbM/maxresdefault.jpg" },
                new Image { GameId = dota2.Id, Url = "https://i.ytimg.com/vi/xqSWUr2bD64/maxresdefault.jpg" },
                new Image { GameId = dota2.Id, Url = "https://i.ytimg.com/vi/6q4htt06vGY/maxresdefault.jpg" }
                );

        }
    }
}
