using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Commands;
using RayHelper.Models;
using Xamarin.Essentials;

namespace RayHelper.ViewModels
{
    public class HospiceListPageViewModel : MainViewModel
    {
        private ObservableCollection<Hospice> _hospices;
        public ObservableCollection<Hospice> Hospices
        {
            get => _hospices;
            set => SetProperty(ref _hospices, value);
        }
        
        public IMvxAsyncCommand<Hospice> OpenHospiceProfileCommand { get; }

        private readonly DbContext _dbContext;
        
        public HospiceListPageViewModel()
        {
            OpenHospiceProfileCommand = new MvxAsyncCommand<Hospice>(OpenHospiceProfileAsync);
            Hospices = new ObservableCollection<Hospice>();

            _dbContext = new DbContext();
            
            //TODO Return back after refactor in Web service
            //LoadData();

            Hospices = new ObservableCollection<Hospice>()
                       {
                           new Hospice()
                           {
                               Name = "Приют 'Дубовая Роща'",
                               City = "Москва",
                               Street = "Проезд Дубовой рощи",
                               HouseNumber = "Вл.23-25",
                               Metro = "Телецентр",
                               Longitude = 55.817648,
                               Latitude = 37.605194,
                               EMail = "dubowaya.rosha@yandex.ru",
                               Mobile = "+7(967)1382161",
                               Website = "https://vk.com/priutme",
                               Photo = "https://thumb.cloud.mail.ru/weblink/thumb/xw1/H1Bp/Yu9jkCG8P",
                               Details = "Сообщество помощи собакам в приюте на Дубовой роще.\r\n📍 Москва\r\n\r\n• Здесь можно узнать о непростой жизни собак, и попробовать сделать её чуть лучше.\r\n\r\nПриют был создан в 2008 году и насчитывает около 900 собак.\r\nВ приюте много не социализированных собак, которые нуждаются в нашем с вами внимании.\r\n👋🏻 Вступайте к нам в группу, будем рады новым волонтерам.\r\nДля получения оперативной информации пишите админам.\r\n___________________________________\r\n\r\n☝🏻 «ВНИМАНИЕ-ВНИМАНИЕ»\r\n\r\nОбращение к тем, кто оставляет у ворот собаку и со спокойной совестью уходит(!)\r\n\r\nРебята, приют муниципальный.\r\n\r\nЭто значит, что животные попадают в приют в результате государственного отлова. Никто из руководства никогда не будет возиться с оставленными в приюте собаками, не говоря уже о щенках, для которых в приюте нет условий.\r\nЛюди, кто вот так приносит животных, таким жестом просто перекладывают их на чужие плечи. Без всякой совести, не оставляя никаких средств, никак не участвуя.\r\nЕсли бы не наши волонтеры, то эти животные так бы и находились, замерзая у приютского забора.\r\nПоэтому,прежде чем сделать как вы считаете\r\nдоброе и благородное дело\r\nподумайте 100 раз , а действительно ли это так."
                           },
                           new Hospice()
                           {
                               Name = "Приют 'Красная сосна'",
                               City = "Москва",
                               Street = "Красная сосна",
                               HouseNumber = "0",
                               Metro = "Ростокино",
                               Longitude = 55.842828,
                               Latitude = 37.679215,
                               EMail = "redpine@bk.ru",
                               Mobile = "+7(963)7677957",
                               Website = "http://priut-ks.ru/",
                               Photo = "https://cloud.mail.ru/public/6A3y/kgU8fJTp5",
                               Details = "..."
                           },
                           new Hospice()
                           {
                               //Поправить опечатку в БД
                               Name = "Приют в Печатниках",
                               City = "Москва",
                               Street = "Проектируемый проезд №5112",
                               HouseNumber = "2",
                               Metro = "Марьино",
                               Longitude = 55.668082,
                               Latitude = 37.70311,
                               EMail = "drug-sobaka@yandex.ru",
                               Mobile = "+7(916)5306494",
                               Website = "https://drug-sobaka.ru/",
                               Photo = "https://cloud.mail.ru/public/eiS3/AhafRvfCZ",
                               Details = "..."
                           },
                           new Hospice()
                           {
                               Name = "Приют 'Кожуховский'",
                               City = "Москва",
                               Street = "Пехорская улица",
                               HouseNumber = "1Б",
                               Metro = "Некрасовка",
                               Longitude = 55.717348,
                               Latitude = 37.929894,
                               EMail = "priutvao@gmail.com",
                               Mobile = "+7(965)2604135",
                               Website = "https://vao-priut.info/",
                               Photo = "https://cloud.mail.ru/public/WY6Z/k7q6HsCBZ",
                               Details = "..."
                           },
                           new Hospice()
                           {
                               Name = "Приют 'Бирюлёво'",
                               City = "Москва",
                               Street = "Востряковский проезд",
                               HouseNumber = "вл10А/2",
                               Metro = "Улица Академика Янгеля",
                               Longitude = 55.582957,
                               Latitude = 37.6165,
                               EMail = "sobaka@izpriuta.ru",
                               Mobile = "+7(963)3319548",
                               Website = "https://izpriuta.ru/",
                               Photo = "https://cloud.mail.ru/public/fGn9/mMtH4rpfb",
                               Details = "..."
                           },
                           new Hospice()
                           {
                               Name = "Приют 'Щербинка'",
                               City = "Москва",
                               Street = "улица Брусилова",
                               HouseNumber = "32",
                               Metro = "",
                               Longitude = 55.498755,
                               Latitude = 37.59895,
                               EMail = "-",
                               Mobile = "+7(905)5523195",
                               Website = "http://sobaka-uzao.ru/",
                               Photo = "https://cloud.mail.ru/public/6eg6/FJnNVMKX4",
                               Details = "..."
                           },
                           new Hospice()
                           {
                               Name = "Приют в 'Одинцово'",
                               City = "Москва",
                               Street = "Рабочий посёлок Большие Вязёмы",
                               HouseNumber = "0",
                               Metro = "",
                               Longitude = 55.634109,
                               Latitude = 36.977024,
                               EMail = "mail@odinpriut.ru",
                               Mobile = "+7(915)1640103",
                               Website = "https://odinpriut.ru/",
                               Photo = "https://cloud.mail.ru/public/VjmZ/jTpejjbtj",
                               Details = "..."
                           },
                       };
        }
        
        public string ClassName => nameof(HospiceListPageViewModel);

        private async void LoadData()
        {
            try
            {
                var hospices = await _dbContext.GetHospices().ConfigureAwait(false);
                
                foreach (var hospice in hospices)
                {
                    Hospices.Add(hospice);
                }
            }
            catch (Exception e)
            {
                Log.Add($"Class name: {ClassName}," +
                        $"Method: {nameof(LoadData)}," +
                        $"Error: {e}");
            }
        }

        private async Task OpenHospiceProfileAsync(Hospice hospice)
        {
            await Navigation.PushAsync(new HospiceProfilePage(hospice));
        }
    }
}