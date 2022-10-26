using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportStore.Common.ModelDto;
using SportStore.Models;
using SportStore.Models.ModelsDB;

namespace SportStore.BusinessLogic.Services
{
    public class GoodsService : IGoodsService
    {
        private readonly SportStoreContext _context;
        private readonly IMapper _mapper;

        public GoodsService(SportStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ClothesDto> Get()
        {
            var clothes = _context.GetClothes
                .Include(gc=>gc.ClothesStore)
                .AsNoTracking()
                .ToList();

            var clothesDto = _mapper.Map<List<ClothesDto>>(clothes);

            return clothesDto;
        }

        public ClothesDto Get(int id)
        {
            var clothes = _context.GetClothes
                .Include(gc=>gc.Characteristic)
                .AsNoTracking()
                .FirstOrDefault(gc => gc.Id == id);

            var clothesDto = _mapper.Map<ClothesDto>(clothes);
            return clothesDto;
        }

        public void Sync()
        {
            var goods = new List<Clothes>
            {
                new Clothes
                {
                    Model = "Your result Спортивные шорты женские для фитнеса",
                    Img = "3.jpeg",
                    Cost = (decimal)56.74,
                    ClothesStore = new ClothesStore{Amount=15},
                    Characteristic = new Characteristic
                    {
                        Season = "Круглогодичный",
                        Gender ="Женский",
                        Type ="Спорт; бег; фитнес",
                        Country ="Китай",
                        Composition="полиамид, спандекс",
                        TypeSize ="42-48, 50-52, 52-54",
                        Description ="Трусы-стринги на каждый день, трусики прекрасно тянутся и держат форму, нижнее белье универсального размера. Стринги выполнены с минимальным количеством швов для приятного и незаметного ощущения на теле. Благодаря высокой посадке трусов визуально удлиняют ноги и красиво сидят по фигуре, придадут округлость вашим ягодицам и соблазнительный, сексуальный, подтянутый вид. Рекомендации по уходу: ручная стирка 30 градусов, не гладить, не отбеливать, не подвергать химчистке, не использовать машинную сушку. "
                    }
                },
                new Clothes
                {
                    Model = "Your2skin - Трусы стринги женские",
                    Img = "your2skin.png",
                    Cost = (decimal)15.59,
                    ClothesStore = new ClothesStore{Amount=15},
                    Characteristic = new Characteristic
                    {
                        Season = "Трусы-стринги на каждый день",
                        Gender ="Женский",
                        Type ="стринги с высокой посадкой",
                        Country ="Китай",
                        Composition="полиамид, спандекс",
                        TypeSize ="42-48, 50-56",
                        Description ="Трусы-стринги на каждый день, трусики прекрасно тянутся и держат форму, нижнее белье универсального размера. Стринги выполнены с минимальным количеством швов для приятного и незаметного ощущения на теле. Благодаря высокой посадке трусов визуально удлиняют ноги и красиво сидят по фигуре, придадут округлость вашим ягодицам и соблазнительный, сексуальный, подтянутый вид. Рекомендации по уходу: ручная стирка 30 градусов, не гладить, не отбеливать, не подвергать химчистке, не использовать машинную сушку. "
                    }
                },
                new Clothes
                {
                    Model = "KOMBEZZ Комбинезон женский спортивный",
                    Img = "1.jpeg",
                    Cost = (decimal)160.62,
                    ClothesStore = new ClothesStore{Amount=4},
                    Characteristic = new Characteristic
                    {
                        Season = "Круглогодичный",
                        Gender ="Женский",
                        Type ="Спортивная одежда. спортивный стиль",
                        Country ="Россия",
                        Composition="эластан 12%, полиэстер 88%",
                        TypeSize ="40-42, 42-44,46-48, 48-50",
                        Description="Спортивный комбенизон женский летний с утягивающим поясом. Перед использованием изделие НЕОБХОДИМО ПОСТИРАТЬ, вывернув наизнанку. Модный комбинезон женский спортивный эластичный. Садится как вторая кожа и не сковывает движений. Стильная спортивная женская одежда для фитнеса и не только."
                    }
                },
                new Clothes
                {
                    Model = "SunriseDance Шорты женские спортивные для танцев зала",
                    Img = "2.jpeg",
                    Cost = (decimal)46.03,
                    ClothesStore = new ClothesStore{Amount=19},
                    Characteristic = new Characteristic
                    {
                        Season = "круглогодичный; лето",
                        Gender ="Женский",
                        Type ="йога poledance тверк стриппластика",
                        Country ="Китай",
                        Composition="полиэстер, спандекс",
                        TypeSize ="40-42, 42-44, 44-46",
                        Description="Короткие секси шортики с высокой талией для тверка, poledance, стрип пластики, обтягивающие, с броским леопардовым принтом - ультрамодный тренд этого года, роскошь и дерзость. Женские шорты для танцев, модные танцевальные трусы-шорты - стрейч, эластичные, легкие, мягкие, из полиэстера и спандекса, коже комфортно, не натирают и не стесняют движений."
                    }
                },
                new Clothes
                {
                    Model = "Мандарини/Топ спортивный",
                    Img = "4.jpeg",
                    Cost = (decimal)19.22,
                    ClothesStore = new ClothesStore{Amount=10},
                    Characteristic = new Characteristic
                    {
                        Season = "круглогодичный; лето",
                        Gender ="Женский",
                        Type ="фитнес; танцы; йога",
                        Country ="Китай",
                        Composition="нейлон, спандекс",
                        TypeSize ="42-44, 44-46, 48-50, 50-52, 54-56, 56-58",
                        Description="Спортивный кроп-топ из качественной эластичной ткани с широкими бретелями и уплотненной резинкой по низу изделия создаст надежную поддержку груди во время тренировок. Топ женский без косточек обеспечивает свободу движения."
                    }
                },
                new Clothes
                {
                    Model = "Me&Mummy/ Бюстгальтер спортивный топ лифчик",
                    Img = "5.jpeg",
                    Cost = (decimal)26.32,
                    ClothesStore = new ClothesStore{Amount=20},
                    Characteristic = new Characteristic
                    {
                        Season = "лето",
                        Gender ="Женский",
                        Type ="фитнес; танцы; Пляжный спорт",
                        Country ="Россия",
                        Composition="Хлопок 95% , эластан 5%",
                        TypeSize ="40-44, 42-46",
                        Description= "Натуральный спортивный бюстгальтер - предмет гардероба, который является обязательным для современной дамы с энергичной жизненной позицией. Забудьте про обтягивающие синтетические модели спортивных топов, выбирайте натуральные хлопковые лифчики с минимальным содержанием эластана. Топ лифт выполнен из приятной ткани, трикотаж в рубчик, который держит форму и не просвечивает.",
                    }
                },
                new Clothes
                {
                    Model = "KICKERS/Брюки спортивные",
                    Img = "6.jpeg",
                    Cost = (decimal)68.62,
                    ClothesStore = new ClothesStore{Amount=10},
                    Characteristic = new Characteristic
                    {
                        Season = "лето",
                        Gender ="Женский",
                        Type ="танцы",
                        Country ="Россия",
                        Composition="полиэстер, спандекс",
                        TypeSize ="40-48",
                        Description="Самая трендовая модель, must have этого года - спортивные брюки клеш - теперь в KICKERS. Идеальная посадка и непревзойденный комфорт вам обеспечены. Экстремально широкий пояс мягко корректирует область талии. Высокая посадка и крой - клеш от колен визуально удлиняет ноги и создает изящный ультрамодный силуэт. "
                    }
                },
            };
            _context.GetClothes.AddRange(goods);
            _context.SaveChanges();
        }
    }
}

