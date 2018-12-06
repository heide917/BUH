using BUH.Domain.Enums;
using BUH.Domain.Models;
using BUH.Domain.Providers.Abstraction;
using BUH.Domain.Repositories;
using BUH.Domain.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.Domain.Services.Concrete
{
    public class FirstRunService : IFirstRunService
    {
        private readonly IConfigProvider _сonfigProvider;
        private readonly ICategorieRepository _сategorieRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IClassRepository _classRepository;

        public FirstRunService(
            IConfigProvider сonfigProvider,
            ICategorieRepository сategorieRepository,
            IAccountRepository accountRepository,
            IClassRepository classRepository)
        {
            _сonfigProvider = сonfigProvider;
            _сategorieRepository = сategorieRepository;
            _accountRepository = accountRepository;
            _classRepository = classRepository;
        }

        public void FillDefaultDataBase()
        {
            int planId;
            string plandIdFomConfig = _сonfigProvider.GetAppKey("Plan");
            var isParsed = Int32.TryParse(plandIdFomConfig, out planId);
            if (isParsed)
            {
                switch (planId)
                {
                    case (int)Plans.NonCommercial:
                        {
                            FillNonCommercialData();
                        }
                        break;
                    case (int)Plans.Budget:
                        {
                            FillBudgetData();
                        }
                        break;
                    default:
                        throw new Exception("Задай 291 или 1203 в поле Plan, в App.config");
                }
            }
            else
            {
                throw new Exception("Некорректно задан Plan в App.config. Укажи число 291 или 1203.");
            }

        }

        #region Заполнение таблиц согласно плану № 291

        private void FillNonCommercialData()
        {
            FillNonCommercialClasses();
            FillNonCommercialCategories();
            FillNonCommercialAccounts();
        }

        private void FillNonCommercialClasses()
        {
            _classRepository.Insert(new Class()
            {
                Number = "1",
                Name = "Необоротні активи",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "2",
                Name = "Запаси",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "3",
                Name = "Кoшти, розрахунки та ін. активи",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "4",
                Name = "Власний капітал тa забезпечення зобов’язaнь",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "5",
                Name = "Довгострокові зобов’язaння",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "6",
                Name = "Поточні зобов’язання",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "7",
                Name = "Доходи і результати діяльностi",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "8",
                Name = "Витрати за елeментами",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "9",
                Name = "Витрати діяльностi",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "0",
                Name = "Позабалансові рахунки",
                Description = ""
            });
        }

        /// <summary>
        /// TODO
        /// </summary>
        private void FillNonCommercialCategories()
        {
            var classes = _classRepository.GetCollection();

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "10",
                Name = "Основні засоби",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "11",
                Name = "Інші необоротні матеріальні aктиви",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "12",
                Name = "Нематеріальні активи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "13",
                Name = "Знос необоротних активів (амортизація)",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "14",
                Name = "Довгострокові фінансові інвестиції",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "15",
                Name = "Капітальні інвестиції",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "16",
                Name = "Довгострокові біологічні активи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "17",
                Name = "Відстрочені податкові активи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "18",
                Name = "Довгострокова дебіторська заборгованість тa інші необоротні активи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "19",
                Name = "Гудвіл",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "20",
                Name = "Виробничі запаси",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "21",
                Name = "Поточні біологічні активи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "22",
                Name = "Малоцінні тa швидкозношувані предмети",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "23",
                Name = "Виробництво",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "24",
                Name = "Брак y виробництві",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "25",
                Name = "Напівфабрикати",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "26",
                Name = "Готова продукція",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "27",
                Name = "Продукція сільськогосподарського виробництва ",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "28",
                Name = "Товари",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "30",
                Name = "Готівка",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "31",
                Name = "Рахунки в банках",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "33",
                Name = "Інші кошти",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "34",
                Name = "Короткострокові векселі одержані",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "35",
                Name = "Поточні фінансові інвестиції",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "36",
                Name = "Розрахунки з покупцями тa замовниками",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "37",
                Name = "Розрахунки з рiзними дебіторами",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "38",
                Name = "Резерв сумнівних боргів",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "39",
                Name = "Витрати майбутніх періодів",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "4").Id,
                Number = "40",
                Name = "Зареєстрований (пайовий) капітал",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "4").Id,
                Number = "41",
                Name = "Капітал у дооцінках",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "4").Id,
                Number = "42",
                Name = "Додатковий капітал",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "4").Id,
                Number = "43",
                Name = "Резервний капітал",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "4").Id,
                Number = "44",
                Name = "Нерозподілені прибутки (нeпокриті збитки)",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "4").Id,
                Number = "45",
                Name = "Вилучений капітал",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "4").Id,
                Number = "46",
                Name = "Неоплачений капітал",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "4").Id,
                Number = "47",
                Name = "Забезпечення майбутніх витрат i платежів",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "4").Id,
                Number = "48",
                Name = "Цільове фінансування i цільові надходження",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "4").Id,
                Number = "49",
                Name = "Страхові резерви",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "5").Id,
                Number = "50",
                Name = "Довгострокові позики",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "5").Id,
                Number = "51",
                Name = "Довгострокові векселі видані",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "5").Id,
                Number = "52",
                Name = "Довгострокові зобов’язання зa облігаціями",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "5").Id,
                Number = "53",
                Name = "Довгострокові зобов’язaння з оренди",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "5").Id,
                Number = "54",
                Name = "Відстрочені податкові зобов’язання",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "5").Id,
                Number = "55",
                Name = "Інші довгострокові зобов’язання",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "60",
                Name = "Короткострокові позики",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "61",
                Name = "Поточна заборгованість зa довгостроковими зобов’язаннями",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "62",
                Name = "Короткострокові векселі видані",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "63",
                Name = "Розрахунки з постачальниками тa підрядниками",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "64",
                Name = "Розрахунки зa податками i платежами",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "65",
                Name = "Розрахунки за страхуванням",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "66",
                Name = "Розрахунки зa виплатами працівникам",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "67",
                Name = "Розрахунки з учасниками",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "68",
                Name = "Розрахунки зa іншими операціями",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "69",
                Name = "Доходи майбутніх періодів",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "7").Id,
                Number = "70",
                Name = "Доходи від реалізації",
                Description = ""
            });


            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "7").Id,
                Number = "71",
                Name = "Інший операційний дохід",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "7").Id,
                Number = "72",
                Name = "Дохід вiд участі в капіталі",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "7").Id,
                Number = "73",
                Name = "Інші фінансові доходи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "7").Id,
                Number = "74",
                Name = "Інші доходи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "7").Id,
                Number = "76",
                Name = "Страхові платежі",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "7").Id,
                Number = "79",
                Name = "Фінансові результaти",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "8").Id,
                Number = "80",
                Name = "Матеріальні витрати",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "8").Id,
                Number = "81",
                Name = "Витрати нa оплату праці",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "8").Id,
                Number = "82",
                Name = "Відрахування нa соціальні заходи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "8").Id,
                Number = "83",
                Name = "Амортизація",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "8").Id,
                Number = "84",
                Name = "Інші операційні витрати",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "8").Id,
                Number = "85",
                Name = "Інші затрати",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "90",
                Name = "Собівартість реалізації",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "91",
                Name = "Загальновиробничі витрати",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "92",
                Name = "Адміністративні витрати",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "93",
                Name = "Витрати на збут",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "94",
                Name = "Іншi витрати операційної діяльності",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "95",
                Name = "Фінансові витрати",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "96",
                Name = "Втрати вiд участі в капіталі",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "97",
                Name = "Інші витрати",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "98",
                Name = "Податок на прибуток",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "01",
                Name = "Орендовані неoборотні активи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "02",
                Name = "Орендовані неoборотні активи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "03",
                Name = "Контрактні зобов’язання",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "04",
                Name = "Непередбачені активи i зобов’язання",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "05",
                Name = "Гарантії тa забезпечення надані",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "06",
                Name = "Гарантії тa забезпечення отримані",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "07",
                Name = "Списані активи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "08",
                Name = "Бланки суворого обліку",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "09",
                Name = "Амортизаційні відрахування",
                Description = ""
            });
        }

        /// <summary>
        /// TODO
        /// </summary>
        private void FillNonCommercialAccounts()
        {
            var сategories = _сategorieRepository.GetCollection();

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "100",
                Name = "Інвестиційна нерухомість",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "101",
                Name = "Земельні ділянки",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "102",
                Name = "Капітальні витрати нa поліпшення земель",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "103",
                Name = "Будинки та споруди",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "104",
                Name = "Машини та обладнання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "105",
                Name = "Транспортні засоби",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "106",
                Name = "Інструменти, прилади та інвентар",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "107",
                Name = "Тварини",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "108",
                Name = "Багаторічні насадження",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "109",
                Name = "Інші основні засоби",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "111",
                Name = "Бібліотечні фонди",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "112",
                Name = "Малоцінні необоротні матеріальні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "113",
                Name = "Тимчасові (нетитульні) споруди",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "114",
                Name = "Природні ресурси",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "115",
                Name = "Iнвентарна тара",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "116",
                Name = "Пpедмети прокату",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "117",
                Name = "Інші необоротні матеріальні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "121",
                Name = "Права користування природними ресурсами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "122",
                Name = "Права користування майном",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "123",
                Name = "Права на комерційні позначення",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "124",
                Name = "Права на oб’єкти промислової власності",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "125",
                Name = "Авторські права тa суміжні з ними права",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "126",
                Name = "Інші нематеріальні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "13").Id,
                Number = "131",
                Name = "Знос основних засобів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "13").Id,
                Number = "132",
                Name = "Знос іншиx необоротних матеріальних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "13").Id,
                Number = "133",
                Name = "Накопичена амортизація нематеріальних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "13").Id,
                Number = "134",
                Name = "Накопичена амортизація довгостроковиx біологічних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "13").Id,
                Number = "135",
                Name = "Знос інвестиційної нерухомості",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "14").Id,
                Number = "141",
                Name = "Інвестиції пов’язаним сторонам зa методом обліку участі в кaпіталі",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "14").Id,
                Number = "142",
                Name = "Інші інвестиції пов’язaним сторонам",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "14").Id,
                Number = "143",
                Name = "Інвестиції непов’язаним сторонам",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "151",
                Name = "Капітальне будівництво",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "152",
                Name = "Придбання (виготовлення) основних засобів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "153",
                Name = "Придбання (виготовлення) іншиx необоротних матеріальних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "154",
                Name = "Придбання (створення) нематеріальних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "155",
                Name = "Придбання (вирощування) довгостроковиx біологічних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "16").Id,
                Number = "161",
                Name = "Довгострокові біологічні активи рослинництвa, якi оцінені за справедливою вартіcтю",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "16").Id,
                Number = "162",
                Name = "Довгострокові біологічні aктиви рослинництва, якi оцінені за первісною вaртістю",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "16").Id,
                Number = "163",
                Name = "Довгострокові біологічні активи тваринництва, якi оцінені за справедливою ваpтістю",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "16").Id,
                Number = "164",
                Name = "Довгострокові біологічні aктиви тваринництва, якi оцінені за первісною вартіcтю",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "16").Id,
                Number = "165",
                Name = "Незрілі довгострокові біологічні активи, якi оцінюються за справедливою вaртістю",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "16").Id,
                Number = "166",
                Name = "Незрілі довгострокові біологічні активи, якi оцінюються за первісною вартiстю",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "18").Id,
                Number = "181",
                Name = "Заборгованість за майно, щo передано у фінансову оренду",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "18").Id,
                Number = "182",
                Name = "Довгострокові векселі одержані",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "18").Id,
                Number = "183",
                Name = "Інша дебіторська заборгованість",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "18").Id,
                Number = "184",
                Name = "Інші необоротні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "19").Id,
                Number = "191",
                Name = "Гудвіл при придбанні",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "19").Id,
                Number = "192",
                Name = "Гудвіл при приватизації (корпоратизації)",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "201",
                Name = "Сировина й матеріали",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "202",
                Name = "Купівельні напівфабрикати тa комплектуючі вироби",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "203",
                Name = "Паливо",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "204",
                Name = "Тара, тарні матеріали",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "205",
                Name = "Будівельні мaтеріали",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "206",
                Name = "Матеріали, передані в перeробку",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "207",
                Name = "Запасні частини",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "208",
                Name = "Матеріaли сільськогосподарського призначення",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "209",
                Name = "Іншi матеріали",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "211",
                Name = "Поточні біологічні aктиви рослинництва, якi оцінені зa справедливою вaртістю",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "212",
                Name = "Поточні біологічні aктиви тваринництва, якi оцінені зa справедливою ваpтістю",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "213",
                Name = "Поточні біологічнi активи тваринництва, якi оцінені за первісною вартіcтю",
                Description = ""
            });


            //уточнить за 22-27 категории


            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "28").Id,
                Number = "281",
                Name = "Товари на складі",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "28").Id,
                Number = "282",
                Name = "Товари в торгівлі",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "28").Id,
                Number = "283",
                Name = "Товари на комісії",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "28").Id,
                Number = "284",
                Name = "Тара під товарами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "28").Id,
                Number = "285",
                Name = "Торгова націнка",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "28").Id,
                Number = "286",
                Name = "Необоротні активи та групи вибyття, утримувані для продажу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "30").Id,
                Number = "301",
                Name = "Готівка в національній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "30").Id,
                Number = "302",
                Name = "Готівка в іноземній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "311",
                Name = "Поточні рахунки в національнiй валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "312",
                Name = "Поточні рахунки в ін. валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "313",
                Name = "Іншi рахунки в бaнку в нац. валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "314",
                Name = "Іншi рахунки в бaнку в ін. валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "315",
                Name = "Спеціальні рахунки в нaціональній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "316",
                Name = "Спеціальні рaхунки в іноземній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "33").Id,
                Number = "331",
                Name = "Грошові документи в нaціональній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "33").Id,
                Number = "332",
                Name = "Грошовi документи в інoзeмній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "33").Id,
                Number = "333",
                Name = "Грошові кoшти в дорозі в нaціональній вaлюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "33").Id,
                Number = "334",
                Name = "Грошові кошти в дopозі в інозeмній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "33").Id,
                Number = "335",
                Name = "Електронні гроші, номінованi в національній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "341",
                Name = "Короткострокові векселі, одержaні в нaціональній вaлюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "342",
                Name = "Короткострокові векселі, oдержані в ін. валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "35").Id,
                Number = "351",
                Name = "Еквіваленти грошових коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "35").Id,
                Number = "352",
                Name = "Інші поточні фінансові інвестиції",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "36").Id,
                Number = "361",
                Name = "Розрахунки з вітчизняними покупцями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "36").Id,
                Number = "362",
                Name = "Розрахунки з іноземними покупцями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "36").Id,
                Number = "363",
                Name = "Розрахунки з учасниками ПФГ",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "36").Id,
                Number = "364",
                Name = "Розрахунки за гарантійним забезпеченням",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "37").Id,
                Number = "371",
                Name = "Розрахунки зa виданими авансами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "37").Id,
                Number = "372",
                Name = "Розрахунки з підзвітними особами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "37").Id,
                Number = "373",
                Name = "Розрахунки за нарахованими доходами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "37").Id,
                Number = "374",
                Name = "Розрахунки за претензіями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "37").Id,
                Number = "375",
                Name = "Розрахунки зa відшкодуванням завданих збитків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "37").Id,
                Number = "376",
                Name = "Розрахунки зa позиками членам кредитних спілок",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "37").Id,
                Number = "377",
                Name = "Розрахунки з іншими дебіторами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "37").Id,
                Number = "378",
                Name = "Розрахунки з держaвними цільовими фондами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "37").Id,
                Number = "379",
                Name = "Розрахунки зa операціями з деривативами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "40").Id,
                Number = "401",
                Name = "Статутний капітал",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "40").Id,
                Number = "402",
                Name = "Пайoвий капітал",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "40").Id,
                Number = "403",
                Name = "Iнший зареєстрований капітал",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "40").Id,
                Number = "404",
                Name = "Внески дo незареєстрованого статутного капіталу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "41").Id,
                Number = "411",
                Name = "Дооцінкa (уцінка) основних засобі",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "41").Id,
                Number = "412",
                Name = "Дооцiнка (уцінка) нематеріальних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "41").Id,
                Number = "413",
                Name = "Доoцінка (уцінка) фінансових інструментів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "41").Id,
                Number = "414",
                Name = "Iнший капітал у дооцінках",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "42").Id,
                Number = "421",
                Name = "Емісійний дохiд",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "42").Id,
                Number = "422",
                Name = "Інший вкладений кaпітал",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "42").Id,
                Number = "423",
                Name = "Накопичені курсові різниц",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "42").Id,
                Number = "424",
                Name = "Безоплатнo одержані необоротні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "42").Id,
                Number = "425",
                Name = "Iнший додатковий капітал",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "44").Id,
                Number = "441",
                Name = "Прибуток нерозподілений",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "44").Id,
                Number = "442",
                Name = "Непокриті збитки",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "44").Id,
                Number = "443",
                Name = "Прибуток, використаний y звітному періоді",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "45").Id,
                Number = "451",
                Name = "Вилучені акції",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "45").Id,
                Number = "452",
                Name = "Вилучені вклади й паї",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "45").Id,
                Number = "453",
                Name = "Інший вилучений капітал",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "47").Id,
                Number = "471",
                Name = "Забезпечення виплат відпусток",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "47").Id,
                Number = "472",
                Name = "Додаткове пенсійне забезпечення",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "47").Id,
                Number = "473",
                Name = "Забезпечення гарантійних зобов’язань",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "47").Id,
                Number = "474",
                Name = "Забезпечення іншиx витрат i платежів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "47").Id,
                Number = "475",
                Name = "Забезпечення призового фонду (рeзерв виплат)",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "47").Id,
                Number = "476",
                Name = "Резерв на виплату джек-поту, нe забезпеченого сплатою участі у лотереї",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "47").Id,
                Number = "477",
                Name = "Забезпечення матеріального заохочення",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "47").Id,
                Number = "478",
                Name = "Забезпечення відновлення земельних ділянок",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "48").Id,
                Number = "481",
                Name = "Кошти, вивільнені від оподаткування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "48").Id,
                Number = "482",
                Name = "Кошти з бюджету тa державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "48").Id,
                Number = "483",
                Name = "Благодійна допомога",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "48").Id,
                Number = "484",
                Name = "Інші кошти цільового фінансування i цiльових надходжень",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "49").Id,
                Number = "491",
                Name = "Технічні резерви",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "49").Id,
                Number = "492",
                Name = "Резерви із страхування життя",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "49").Id,
                Number = "493",
                Name = "Частка перестраховиків y технічних резервах",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "49").Id,
                Number = "494",
                Name = "Частка перестраховиків у резервах iз страхування життя",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "49").Id,
                Number = "495",
                Name = "Результат зміни технічних резервів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "49").Id,
                Number = "496",
                Name = "Результат зміни резервів iз страхування життя",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "50").Id,
                Number = "501",
                Name = "Довгостроковi кредити банків y нац. валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "50").Id,
                Number = "502",
                Name = "Довгострокові кредити бaнків в іноземній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "50").Id,
                Number = "503",
                Name = "Вiдстрочені довгострокові кредити банкiв y національній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "50").Id,
                Number = "504",
                Name = "Відстрочені дpвгострокові кредити бaнків в іноземній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "50").Id,
                Number = "505",
                Name = "Інші довгострокові позики в нaціональній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "50").Id,
                Number = "506",
                Name = "Іншi довгострокові позики в iноземній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "51").Id,
                Number = "511",
                Name = "Довгострокові векселі, виданi в нaц. валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "51").Id,
                Number = "512",
                Name = "Довгострокові векселі, видані в ін. валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "52").Id,
                Number = "521",
                Name = "Зобов’язання зa облігаціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "52").Id,
                Number = "522",
                Name = "Премія зa випущеними облігаціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "52").Id,
                Number = "523",
                Name = "Дисконт зa випущеними облігаціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "53").Id,
                Number = "531",
                Name = "Зобов’язaння з фінансової оренди",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "53").Id,
                Number = "532",
                Name = "Зобов’язaння з оренди цiлісниx майнових комплексів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "601",
                Name = "Короткострокові кредити банків у нац. валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "602",
                Name = "Короткострокові кредити бaнків в ін. валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "603",
                Name = "Відстрочені короткострокoві кредити банків y нац. валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "604",
                Name = "Відстрочені короткострокові крeдити банкiв в ін. валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "605",
                Name = "Прострочені позики в наці. валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "606",
                Name = "Прострочені позики в іноземній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "611",
                Name = "Поточна заборгованість зa довгостроковими зобов’язaннями в національній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "612",
                Name = "Поточна заборгованість зa довгостроковими зобов’язаннями в ін. валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "62").Id,
                Number = "621",
                Name = "Короткострокові векселі, видані в нац. валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "62").Id,
                Number = "622",
                Name = "Короткострокові векселі, видaні в ін. валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "63").Id,
                Number = "631",
                Name = "Розрахунки з вітчизняними постачальниками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "63").Id,
                Number = "632",
                Name = "Розрахунки з іноземними постачальниками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "63").Id,
                Number = "633",
                Name = "Розрахунки з учасниками ПФГ",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "641",
                Name = "Розрахунки зa податками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "642",
                Name = "Розрахунки зa обов’язковими платежами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "643",
                Name = "Податкові зобов’язання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "644",
                Name = "Податковий кредит",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "651",
                Name = "За розрахунками iз загальнообов’язкового державного соціального страхувaння",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "652",
                Name = "За соціальним страхуванням",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "654",
                Name = "За індивідуальним страхуванням",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "655",
                Name = "За страхуванням майна",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "66").Id,
                Number = "661",
                Name = "Розрахунки за заробітною платою",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "66").Id,
                Number = "662",
                Name = "Розрахунки з депонентами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "66").Id,
                Number = "663",
                Name = "Розрахунки за іншими виплатами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "67").Id,
                Number = "671",
                Name = "Розрахунки за нарахованими дивідендами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "67").Id,
                Number = "672",
                Name = "Розрахунки за іншими виплатами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "68").Id,
                Number = "680",
                Name = "Розрахунки, пов’язані з нeоборотними активами та групами вибуття, утримувaними для продажу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "68").Id,
                Number = "681",
                Name = "Розрахунки за авансами одержаними",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "68").Id,
                Number = "682",
                Name = "Внутрішні розрахунки",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "68").Id,
                Number = "683",
                Name = "Внутрішньогосподарські розрахунки",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "68").Id,
                Number = "684",
                Name = "Розрахунки за нарахованими відсотками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "68").Id,
                Number = "685",
                Name = "Розрахунки з іншими кредиторами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "70").Id,
                Number = "701",
                Name = "Дохід вiд реалізації готової продукції",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "70").Id,
                Number = "702",
                Name = "Дохiд від реалізації товарів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "70").Id,
                Number = "703",
                Name = "Доxід від реалізації робіт, пoслуг",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "70").Id,
                Number = "704",
                Name = "Вирахування з дохoду",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "70").Id,
                Number = "705",
                Name = "Перестрахування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "71").Id,
                Number = "710",
                Name = "Дохід від первісного визнання тa від зміни вартості активів, якi обліковуються за справедливою вартістю",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "71").Id,
                Number = "711",
                Name = "Дохід вiд купівлі-продажу іноземної валюти",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "71").Id,
                Number = "712",
                Name = "Дохід вiд реалізації іншиx оборотних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "71").Id,
                Number = "713",
                Name = "Дохід вiд операційної оренди активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "71").Id,
                Number = "714",
                Name = "Дохiд вiд операційної курсової різницi",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "71").Id,
                Number = "715",
                Name = "Одержанi штрафи, пені, неустойки",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "71").Id,
                Number = "716",
                Name = "Відшкoдувaння раніше списаних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "71").Id,
                Number = "717",
                Name = "Дохід вiд списання кредиторської заборгованості",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "71").Id,
                Number = "718",
                Name = "Дoхід вiд безоплатно одержаних оборотних aктивів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "71").Id,
                Number = "719",
                Name = "Інші доходи вiд операційної діяльності",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "72").Id,
                Number = "721",
                Name = "Дохід від інвестицій в асoційовані підприємства",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "72").Id,
                Number = "722",
                Name = "Дохід вiд спільної діяльності",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "72").Id,
                Number = "723",
                Name = "Дoхід вiд інвестицій в дочірні пiдприємства",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "73").Id,
                Number = "731",
                Name = "Дивіденди одержані",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "73").Id,
                Number = "732",
                Name = "Відсотки одержані",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "73").Id,
                Number = "733",
                Name = "Інші доходи вiд фінансових операцій",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "74").Id,
                Number = "740",
                Name = "Дохід вiд зміни вартості фінансових інструментів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "74").Id,
                Number = "741",
                Name = "Дохід вiд реалізації фінансових інвестицій",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "74").Id,
                Number = "742",
                Name = "Дoхід вiд відновлення корисності активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "74").Id,
                Number = "744",
                Name = "Дохід вiд неопераційної курсової різниці",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "74").Id,
                Number = "745",
                Name = "Дохід вiд безоплатно одержаних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "74").Id,
                Number = "746",
                Name = "Дохід вiд безоплатно одержаних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "79").Id,
                Number = "791",
                Name = "Результат операційної діяльності",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "79").Id,
                Number = "792",
                Name = "Результaт фінансових операцій",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "79").Id,
                Number = "793",
                Name = "Результат iншої звичайної діяльності",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "801",
                Name = "Витрати сировини й матеріалів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "802",
                Name = "Витрати купівельних напівфабрикатів тa комплектуючих виробів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "803",
                Name = "Витрати палива, енергії",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "804",
                Name = "Витрати тари, тaрних матеріалів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "805",
                Name = "Витрати будівельних мaтеріалів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "806",
                Name = "Витрати запасних чаcтин",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "807",
                Name = "Витрати матеріалів сільськогосподарського пpизначення",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "808",
                Name = "Витрaти товарів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "809",
                Name = "Іншi матеріальні витрати",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "81").Id,
                Number = "811",
                Name = "Виплати за окладами, тарифами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "81").Id,
                Number = "812",
                Name = "Премії та заохочення",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "81").Id,
                Number = "813",
                Name = "Компенсаційні виплати",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "81").Id,
                Number = "814",
                Name = "Оплата відпусток",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "81").Id,
                Number = "815",
                Name = "Оплата іншого невідпрацьованого часу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "81").Id,
                Number = "816",
                Name = "Інші витрати нa оплату праці",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "82").Id,
                Number = "821",
                Name = "Відрахування на загальнообов’язковr державне соціальне страхування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "83").Id,
                Number = "831",
                Name = "Амортизація основних засобів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "83").Id,
                Number = "832",
                Name = "Амортизація іншиx необоротних матеріальних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "83").Id,
                Number = "833",
                Name = "Амортизація нематеріальних активiв",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "90").Id,
                Number = "901",
                Name = "Собівартість реалізованої готової продукції",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "90").Id,
                Number = "902",
                Name = "Сoбівартість реалізованих товарів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "90").Id,
                Number = "903",
                Name = "Собівартість рeалізованих робіт, поcлуг",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "90").Id,
                Number = "904",
                Name = "Страхові виплати",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "940",
                Name = "Витрати від первісного визнання тa від зміни вартості активів, якi обліковуються за справедливою вартістю",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "941",
                Name = "Витрати на дослідження, розробки",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "942",
                Name = "Витрати нa купівлю-продаж іноземної валюти",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "943",
                Name = "Собівартість реалізованиx виробничих запасів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "944",
                Name = "Сумнівні тa безнадійні борги",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "945",
                Name = "Втрати вiд операційної курсової різниці",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "946",
                Name = "Втрaти від знецінення запасiв",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "947",
                Name = "Нестачі і втрати вiд псування цінностей",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "948",
                Name = "Визнанi штрафи, пені, неустойки",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "949",
                Name = "Іншi витрати операційної діяльностi",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "95").Id,
                Number = "951",
                Name = "Відсотки за кредит",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "95").Id,
                Number = "952",
                Name = "Іншi фінансові витрати",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "961",
                Name = "Втрати від інвестицій в aсоційовані підприємства",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "962",
                Name = "Втрати вiд спільної діяльності",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "963",
                Name = "Втрати вiд інвестицій в дoчірні підприємствa",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "970",
                Name = "Витрати вiд зміни вартості фінансових інструментів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "971",
                Name = "Собівартість реалізованих фінансових інвестицiй",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "972",
                Name = "Втрати вiд зменшення корисності активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "974",
                Name = "Втрати вiд неопераційних курсових різниць",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "975",
                Name = "Уцінка необоротних активів та фінансових інвестицій",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "976",
                Name = "Списання нeоборотних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "977",
                Name = "Інші витрати діяльності",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "98").Id,
                Number = "981",
                Name = "Податок нa прибуток вiд звичайної діяльності",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "98").Id,
                Number = "982",
                Name = "Податок на прибуток вiд надзвичайних подiй",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "02").Id,
                Number = "021",
                Name = "Устаткування, пpийняте для монтажу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "02").Id,
                Number = "022",
                Name = "Матеріали, прийняті для переробки",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "02").Id,
                Number = "023",
                Name = "Матеріальні цінності нa відповідальному зберіганні",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "02").Id,
                Number = "024",
                Name = "Товари, прийняті на комісію",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "02").Id,
                Number = "025",
                Name = "Матеріальні цінності довірителя",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "04").Id,
                Number = "041",
                Name = "Непередбачені активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "04").Id,
                Number = "042",
                Name = "Непередбачені зобов’язання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "04").Id,
                Number = "042",
                Name = "Непередбачені зобов’язання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "04").Id,
                Number = "071",
                Name = "Списана дебіторська заборгованість",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "04").Id,
                Number = "072",
                Name = "Невідшкодовані нестачі i втрати вiд псування цінностей",
                Description = ""
            });


        }


        #endregion

        #region Заполнение таблиц согласно плану № 1203

        private void FillBudgetData()
        {
            FillBudgetDataClasses();
            FillBudgetDataCategories();
            FillBudgetDataAccounts();
        }

        private void FillBudgetDataClasses()
        {
            _classRepository.Insert(new Class()
            {
                Number = "1",
                Name = "Нефінансові активи",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "2",
                Name = "Фінансові активи",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "3",
                Name = "Кошти бюджетів та розпорядників бюджетних коштів",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "4",
                Name = "Розрахунки",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "5",
                Name = "Капітал та фінансовий результат",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "6",
                Name = "Зобов’язання",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "7",
                Name = "Доходи",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "8",
                Name = "Витрати",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "9",
                Name = "Позабалансові та управлінські рахунки бюджетів та державних цільових фондів",
                Description = ""
            });

            _classRepository.Insert(new Class()
            {
                Number = "0",
                Name = "Позабалансові рахунки розпорядників бюджетних коштів та державних цільових фондів",
                Description = ""
            });
        }

        /// <summary>
        /// TODO
        /// </summary>
        private void FillBudgetDataCategories()
        {
            var classes = _classRepository.GetCollection();

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "10",
                Name = "Основні засоби",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "11",
                Name = "Інші необоротні матеріальні активи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "12",
                Name = "Нематеріальні активи",
                Description = ""
            });


            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "13",
                Name = "Капітальні інвестиції",
                Description = ""
            });


            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "14",
                Name = "Знос (амортизація) необоротних активів",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "15",
                Name = "Виробничі запаси",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "16",
                Name = "Виробництво",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "17",
                Name = "Біологічні активи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "1").Id,
                Number = "18",
                Name = "Інші нефінансові активи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "20",
                Name = "Довгострокова дебіторська заборгованість",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "21",
                Name = "Поточна дебіторська заборгованість",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "22",
                Name = "Готівкові кошти та їх еквіваленти",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "23",
                Name = "Грошові кошти на рахунках",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "24",
                Name = "Єдиний казначейський рахунок",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "25",
                Name = "Довгострокові фінансові інвестиції та інші фінансові активи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "26",
                Name = "Поточні фінансові інвестиції та інші фінансові активи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "27",
                Name = "Дебіторська заборгованість за внутрішніми розрахунками",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "28",
                Name = "Розрахунки за надходженнями до бюджету",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "2").Id,
                Number = "29",
                Name = "Витрати майбутніх періодів",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "31",
                Name = "Надходження бюджету",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "32",
                Name = "Кошти бюджету",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "33",
                Name = "Кошти бюджету, які підлягають розподілу",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "34",
                Name = "Рахунки розпорядників та одержувачів бюджетних коштів, інші рахунки для здійснення витрат",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "35",
                Name = "Інші рахунки розпорядників бюджетних коштів та рахунки інших клієнтів",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "36",
                Name = "Рахунки за нез’ясованими сумами та інші транзитні рахунки",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "37",
                Name = "Рахунки органів Казначейства",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "3").Id,
                Number = "38",
                Name = "Рахунки, відкриті в системі електронного адміністрування податків",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "4").Id,
                Number = "41",
                Name = "Розрахунки за фінансовими операціями",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "4").Id,
                Number = "42",
                Name = "Інші розрахунки",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "4").Id,
                Number = "43",
                Name = "Розрахунки за коштами, які підлягають розподілу",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "4").Id,
                Number = "44",
                Name = "Позиція щодо іноземної валюти та балансуючі рахунки",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "4").Id,
                Number = "45",
                Name = "Накопичувальні рахунки для обліку надходжень до бюджетів, які підлягають розподілу",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "4").Id,
                Number = "46",
                Name = "Технічні рахунки",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "5").Id,
                Number = "51",
                Name = "Внесений капітал",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "5").Id,
                Number = "52",
                Name = "Капітал у підприємствах",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "5").Id,
                Number = "53",
                Name = "Капітал у дооцінках",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "5").Id,
                Number = "54",
                Name = "Цільове фінансування",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "5").Id,
                Number = "55",
                Name = "Фінансовий результат",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "5").Id,
                Number = "56",
                Name = "Резервний капітал",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "60",
                Name = "Довгострокові зобов’язання",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "61",
                Name = "Поточна заборгованість за кредитами та позиками",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "62",
                Name = "Розрахунки за товари, роботи, послуги",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "63",
                Name = "Розрахунки за податками і зборами",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "64",
                Name = "Інші поточні зобов’язання",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "65",
                Name = "Розрахунки з оплати праці",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "66",
                Name = "Зобов’язання за внутрішніми розрахунками",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "67",
                Name = "Забезпечення майбутніх витрат і платежів",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "68",
                Name = "Зобов’язання за надходженнями до бюджету",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "6").Id,
                Number = "69",
                Name = "Доходи майбутніх періодів",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "7").Id,
                Number = "70",
                Name = "Доходи за бюджетними асигнуваннями",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "7").Id,
                Number = "71",
                Name = "Доходи від реалізації продукції (робіт, послуг)",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "7").Id,
                Number = "72",
                Name = "Доходи від продажу активів",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "7").Id,
                Number = "73",
                Name = "Фінансові доходи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "7").Id,
                Number = "74",
                Name = "Інші доходи за обмінними операціями",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "7").Id,
                Number = "75",
                Name = "Доходи за необмінними операціями",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "7").Id,
                Number = "76",
                Name = "Умовні доходи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "8").Id,
                Number = "80",
                Name = "Витрати на виконання бюджетних програм",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "8").Id,
                Number = "81",
                Name = "Витрати на виготовлення продукції (надання послуг, виконання робіт)",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "8").Id,
                Number = "82",
                Name = "Витрати з продажу активів",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "8").Id,
                Number = "83",
                Name = "Фінансові витрати",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "8").Id,
                Number = "84",
                Name = "Інші витрати за обмінними операціями",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "8").Id,
                Number = "85",
                Name = "Витрати за необмінними операціями",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "8").Id,
                Number = "86",
                Name = "Умовні витрати",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "90",
                Name = "Пропозиції та відкриті асигнування",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "91",
                Name = "Асигнування",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "92",
                Name = "Показники розпису",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "93",
                Name = "Бюджетні зобов’язання розпорядників та одержувачів бюджетних коштів, розрахункові документи, не оплачені",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "94",
                Name = "Нараховані відсотки, плата за надання державних гарантій і кредитів (позик), залучених державою, та штрафні санкції",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "95",
                Name = "Зобов’язання і вимоги за кредитуванням, всіма видами гарантій та цінними паперами",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "96",
                Name = "Емітовані цінні папери",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "97",
                Name = "Рахунки для обліку коштів та розрахунків, отриманих",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "98",
                Name = "Рахунки для обліку коштів, переданих",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "9").Id,
                Number = "99",
                Name = "Контррахунки до рахунків позабалансового обліку",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "01",
                Name = "Орендовані основні засоби та нематеріальні активи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "02",
                Name = "Активи на відповідальному зберіганні",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "03",
                Name = "Бюджетні зобов'язання",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "04",
                Name = "Непередбачені активи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "05",
                Name = "Непередбачені зобов’язання, гарантії та забезпечення надані",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "06",
                Name = "Гарантії та забезпечення отримані",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "07",
                Name = "Списані активи",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "08",
                Name = "Бланки документів суворої звітності",
                Description = ""
            });

            _сategorieRepository.Insert(new Categorie()
            {
                ClassId = classes.First(x => x.Number == "0").Id,
                Number = "09",
                Name = "Передані (видані) активи відповідно до законодавства",
                Description = ""
            });



        }

        /// <summary>
        /// TODO
        /// </summary>
        private void FillBudgetDataAccounts()
        {
            var сategories = _сategorieRepository.GetCollection();

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1010",
                Name = "Інвестиційна нерухомість",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1011",
                Name = "Земельні ділянки",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1012",
                Name = "Капітальні витрати на поліпшення земель",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1013",
                Name = "Будівлі, споруди та передавальні пристрої",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1014",
                Name = "Машини та обладнання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1015",
                Name = "Транспортні засоби",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1016",
                Name = "Інструменти, прилади, інвентар",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1017",
                Name = "Тварини та багаторічні насадження",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1018",
                Name = "Інші основні засоби",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1020",
                Name = "Інвестиційна нерухомість",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1021",
                Name = "Земельні ділянки",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1022",
                Name = "Капітальні витрати на поліпшення земель",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1023",
                Name = "Будівлі, споруди та передавальні пристрої",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1024",
                Name = "Машини та обладнання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1025",
                Name = "Транспортні засоби",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1026",
                Name = "Інструменти, прилади, інвентар",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1027",
                Name = "Тварини та багаторічні насадження",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "10").Id,
                Number = "1028",
                Name = "Інші основні засоби",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "1111",
                Name = "Музейні фонди",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "1112",
                Name = "Бібліотечні фонди",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "1113",
                Name = "Малоцінні необоротні матеріальні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "1114",
                Name = "Білизна, постільні речі, одяг та взуття",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "1115",
                Name = "Інвентарна тара",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "1116",
                Name = "Необоротні матеріальні активи спеціального призначення",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "1117",
                Name = "Природні ресурси",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "1118",
                Name = "Інші необоротні матеріальні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "1121",
                Name = "Музейні фонди",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "1122",
                Name = "Бібліотечні фонди",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "1123",
                Name = "Малоцінні необоротні матеріальні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "1124",
                Name = "Білизна, постільні речі, одяг та взуття",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "1125",
                Name = "Інвентарна тара",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "1126",
                Name = "Необоротні активи спецпризначення для розподілу, передачі",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "11").Id,
                Number = "1127",
                Name = "Інші необоротні матеріальні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "1211",
                Name = "Авторське та суміжні з ним права",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "1212",
                Name = "Права користування природними ресурсами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "1213",
                Name = "Права на знаки для товарів і послуг",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "1214",
                Name = "Права користування майном",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "1215",
                Name = "Права на об'єкти промислової власності",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "1216",
                Name = "Інші нематеріальні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "1221",
                Name = "Авторське та суміжні з ним права",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "1222",
                Name = "Права користування природними ресурсами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "1223",
                Name = "Права на знаки для товарів і послуг",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "1224",
                Name = "Права користування майном",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "1225",
                Name = "Права на об'єкти промислової власності",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "12").Id,
                Number = "1226",
                Name = "Інші нематеріальні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "13").Id,
                Number = "1311",
                Name = "Капітальні інвестиції в основні засоби",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "13").Id,
                Number = "1312",
                Name = "Капітальні інвестиції в інші необоротні матеріальні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "13").Id,
                Number = "1313",
                Name = "Капітальні інвестиції в нематеріальні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "13").Id,
                Number = "1314",
                Name = "Капітальні інвестиції в довгострокові біологічні активи",
                Description = ""
            });


            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "13").Id,
                Number = "1321",
                Name = "Капітальні інвестиції в основні засоби",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "13").Id,
                Number = "1322",
                Name = "Капітальні інвестиції в інші необоротні матеріальні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "13").Id,
                Number = "1323",
                Name = "Капітальні інвестиції в нематеріальні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "13").Id,
                Number = "1324",
                Name = "Капітальні інвестиції в необоротні активи спецпризначення",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "13").Id,
                Number = "1325",
                Name = "Капітальні інвестиції в довгострокові біологічні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "14").Id,
                Number = "1411",
                Name = "Капітальні інвестиції в довгострокові біологічні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "14").Id,
                Number = "1412",
                Name = "Знос інших необоротних матеріальних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "14").Id,
                Number = "1413",
                Name = "Накопичена амортизація нематеріальних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "14").Id,
                Number = "1414",
                Name = "Знос інвестиційної нерухомості",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "14").Id,
                Number = "1415",
                Name = "Накопичена амортизація довгострокових біологічних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "14").Id,
                Number = "1421",
                Name = "Капітальні інвестиції в довгострокові біологічні активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "14").Id,
                Number = "1422",
                Name = "Знос інших необоротних матеріальних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "14").Id,
                Number = "1423",
                Name = "Накопичена амортизація нематеріальних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "14").Id,
                Number = "1424",
                Name = "Знос інвестиційної нерухомості",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "14").Id,
                Number = "1425",
                Name = "Накопичена амортизація довгострокових біологічних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "1511",
                Name = "Продукти харчування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "1512",
                Name = "Медикаменти та перев’язувальні матеріали",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "1513",
                Name = "Будівельні матеріали",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "1514",
                Name = "Пально-мастильні матеріали",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "1515",
                Name = "Запасні частини",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "1516",
                Name = "Тара",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "1517",
                Name = "Сировина і матеріали",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "1518",
                Name = "Інші виробничі запаси",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "1521",
                Name = "Продукти харчування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "1522",
                Name = "Медикаменти та перев’язувальні матеріали",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "1523",
                Name = "Будівельні матеріали",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "1524",
                Name = "Пально-мастильні матеріали",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "1525",
                Name = "Запасні частини",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "1526",
                Name = "Тара",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "1527",
                Name = "Сировина і матеріали",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "15").Id,
                Number = "1528",
                Name = "Інші виробничі запаси",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "16").Id,
                Number = "1611",
                Name = "Науково-дослідні роботи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "16").Id,
                Number = "1612",
                Name = "Виготовлення експериментальних приладів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "16").Id,
                Number = "1613",
                Name = "Інше виробництво",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "16").Id,
                Number = "1621",
                Name = "Науково-дослідні роботи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "16").Id,
                Number = "1622",
                Name = "Виготовлення експериментальних приладів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "16").Id,
                Number = "1623",
                Name = "Інше виробництво",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "17").Id,
                Number = "1711",
                Name = "Довгострокові біологічні активи рослинництва",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "17").Id,
                Number = "1712",
                Name = "Довгострокові біологічні активи тваринництва",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "17").Id,
                Number = "1713",
                Name = "Поточні біологічні активи рослинництва",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "17").Id,
                Number = "1714",
                Name = "Поточні біологічні активи тваринництва",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "17").Id,
                Number = "1721",
                Name = "Довгострокові біологічні активи рослинництва",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "17").Id,
                Number = "1722",
                Name = "Довгострокові біологічні активи тваринництва",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "17").Id,
                Number = "1723",
                Name = "Поточні біологічні активи рослинництва",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "17").Id,
                Number = "1724",
                Name = "Поточні біологічні активи тваринництва",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "18").Id,
                Number = "1811",
                Name = "Готова продукція",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "18").Id,
                Number = "1812",
                Name = "Малоцінні та швидкозношувані предмети",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "18").Id,
                Number = "1814",
                Name = "Державні матеріальні резерви та запаси",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "18").Id,
                Number = "1815",
                Name = "Активи для розподілу, передачі, продажу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "18").Id,
                Number = "1816",
                Name = "Інші нефінансові активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "18").Id,
                Number = "1821",
                Name = "Готова продукція",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "18").Id,
                Number = "1822",
                Name = "Малоцінні та швидкозношувані предмети",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "18").Id,
                Number = "1824",
                Name = "Державні матеріальні резерви та запаси",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "18").Id,
                Number = "1825",
                Name = "Активи для розподілу, передачі, продажу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "18").Id,
                Number = "1826",
                Name = "Інші нефінансові активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2011",
                Name = "Довгострокова дебіторська заборгованість за операціями з оренди",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2012",
                Name = "Довгострокові кредити, надані розпорядниками бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2013",
                Name = "Інша довгострокова дебіторська заборгованість",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2021",
                Name = "Довгострокова дебіторська заборгованість за операціями з оренди",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2022",
                Name = "Довгострокові кредити, надані з бюджету державного цільового фонду",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2023",
                Name = "Інша довгострокова дебіторська заборгованість",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2031",
                Name = "Довгострокові кредити, надані з державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2032",
                Name = "Прострочена заборгованість за довгостроковими кредитами, наданими з державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2033",
                Name = "Довгострокові кредити, надані з державного бюджету, за ліквідованими юридичними особами - позичальниками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2034",
                Name = "Інша заборгованість за довгостроковими кредитами, наданими з державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2035",
                Name = "Дебіторська заборгованість за довгостроковими кредитами, що надавались під державні гарантії та/або за рахунок коштів, залучених державою",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2036",
                Name = "Прострочена заборгованість за довгостроковими кредитами, що надавались під державні гарантії та/або за рахунок коштів, залучених державою",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2037",
                Name = "Дебіторська заборгованість за довгостроковими кредитами, що надавались під державні гарантії та/або за рахунок коштів, залучених державою, за ліквідованими юридичними особами - позичальниками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2038",
                Name = "Інша заборгованістьза довгостроковими кредитами, що надавались під державні гарантії та/або за рахунок коштів, залучених державою",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2039",
                Name = "Інша довгострокова дебіторська заборгованість державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2041",
                Name = "Довгострокові кредити, надані з державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2042",
                Name = "Прострочена заборгованість за довгостроковими кредитами, наданими з місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2043",
                Name = "Довгострокові кредити, надані з місцевих бюджетів, за ліквідованими юридичними особами - позичальниками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2044",
                Name = "Інша заборгованість за довгостроковими кредитами, наданими з місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2045",
                Name = "Дебіторська заборгованість за довгостроковими кредитами, що надавались під місцеві гарантії та/або за рахунок коштів, залучених місцевими бюджетами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2046",
                Name = "Прострочена заборгованість за довгостроковими кредитами, що надавались під місцеві гарантії та/або за рахунок коштів, залучених місцевими бюджетами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2047",
                Name = "Дебіторська заборгованість за довгостроковими кредитами, що надавались під місцеві гарантії та/або за рахунок коштів, залучених місцевими бюджетами, за ліквідованими юридичними особами - позичальниками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2048",
                Name = "Інша заборгованість за довгостроковими кредитами, що надавались під місцеві гарантії та/або за рахунок коштів, залучених місцевими бюджетами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "20").Id,
                Number = "2049",
                Name = "Інша довгострокова дебіторська заборгованість місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2110",
                Name = "Дебіторська заборгованість за розрахунками з бюджетом",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2111",
                Name = "Поточна дебіторська заборгованість за розрахунками за товари, роботи, послуги",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2112",
                Name = "Дебіторська заборгованість за короткостроковими кредитами, наданими розпорядниками бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2113",
                Name = "Розрахунки за авансами, виданими постачальникам, підрядникам за товари, роботи і послуги",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2114",
                Name = "Дебіторська заборгованість за розрахунками із соціального страхування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2115",
                Name = "Розрахунки з відшкодування завданих збитків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2116",
                Name = "Дебіторська заборгованість за розрахунками з підзвітними особами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2117",
                Name = "Інша поточна дебіторська заборгованість",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2118",
                Name = "Розрахунки із спільної діяльності",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2120",
                Name = "Дебіторська заборгованість за розрахунками з бюджетом",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2121",
                Name = "Поточна дебіторська заборгованість за розрахунками за товари, роботи, послуги",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2122",
                Name = "Дебіторська заборгованість за короткостроковими кредитами, наданими державними цільовими фондами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2123",
                Name = "Розрахунки за авансами, виданими постачальникам, підрядникам за товари, роботи і послуги",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2124",
                Name = "Дебіторська заборгованість за розрахунками із соціального страхування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2125",
                Name = "Розрахунки з відшкодування завданих збитків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2126",
                Name = "Дебіторська заборгованість за розрахунками з підзвітними особами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2127",
                Name = "Дебіторська заборгованість за претензіями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2128",
                Name = "Інша поточна дебіторська заборгованість",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2129",
                Name = "Розрахунки із спільної діяльності",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2130",
                Name = "Короткострокові кредити, надані з державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2131",
                Name = "Прострочена заборгованість за короткостроковими кредитами, наданими з державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2132",
                Name = "Короткострокові кредити, надані з державного бюджету, за ліквідованими юридичними особами - позичальниками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2133",
                Name = "Інша заборгованість за короткостроковими кредитами, наданими з державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2134",
                Name = "Дебіторська заборгованість за короткостроковими кредитами, що надавались під державні гарантії та/або за рахунок коштів, залучених державою",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2135",
                Name = "Прострочена заборгованість за короткостроковими кредитами, що надавались під державні гарантії та/або за рахунок коштів, залучених державою",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2136",
                Name = "Дебіторська заборгованість за короткостроковими кредитами, що надавались під державні гарантії та/або за рахунок коштів, залучених державою, за ліквідованими юридичними особами - позичальниками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2137",
                Name = "Інша заборгованість за короткостроковими кредитами, що надавались під державні гарантії та/або за рахунок коштів, залучених державою",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2138",
                Name = "Інша поточна дебіторська заборгованість державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2140",
                Name = "Короткострокові кредити, надані з місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2141",
                Name = "Прострочена заборгованість за короткостроковими кредитами, наданими з місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2142",
                Name = "Короткострокові кредити, надані з місцевих бюджетів, за ліквідованими юридичними особами - позичальниками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2143",
                Name = "Інша заборгованість за короткостроковими кредитами, наданими з місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2144",
                Name = "Дебіторська заборгованість за короткостроковими кредитами, що надавались під місцеві гарантії та/або за рахунок коштів, залучених місцевими бюджетами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2145",
                Name = "Прострочена заборгованість за короткостроковими кредитами, що надавались під місцеві гарантії та/або за рахунок коштів, залучених місцевими бюджетами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2146",
                Name = "Дебіторська заборгованість за короткостроковими кредитами, що надавались під місцеві гарантії та/або за рахунок коштів, залучених місцевими бюджетами, за ліквідованими юридичними особами - позичальниками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2147",
                Name = "Інша заборгованість за короткостроковими кредитами, що надавались під місцеві гарантії та/або за рахунок коштів, залучених місцевими бюджетами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2148",
                Name = "Інша поточна дебіторська заборгованість місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2150",
                Name = "Короткострокові позики, надані місцевим бюджетам за рахунок коштів єдиного казначейського рахунку",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2151",
                Name = "Середньострокові позики, надані місцевим бюджетам за рахунок коштів єдиного казначейського рахунку",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2152",
                Name = "Пролонговані позики, надані місцевим бюджетам за рахунок коштів єдиного казначейського рахунку",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2153",
                Name = "Прострочена заборгованість за позиками, наданими місцевими бюджетами за рахунок коштів єдиного казначейського рахунку",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2154",
                Name = "Короткострокові позики, надані за рахунок коштів єдиного казначейського рахунку головним розпорядникам коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2155",
                Name = "Прострочена заборгованість за позиками, наданими за рахунок коштів єдиного казначейського рахунку головним розпорядникам коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2156",
                Name = "Короткострокові позики, надані за рахунок коштів єдиного казначейського рахунку Пенсійному фонду та іншим клієнтам",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2157",
                Name = "Прострочена заборгованість за позиками, наданими за рахунок коштів єдиного казначейського рахунку Пенсійному фонду та іншим клієнтам",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2158",
                Name = "Дебіторська заборгованість за операціями з готівкою",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "21").Id,
                Number = "2159",
                Name = "Інша дебіторська заборгованість за операціями з банками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "22").Id,
                Number = "2211",
                Name = "Готівка у національній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "22").Id,
                Number = "2212",
                Name = "Готівка в іноземній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "22").Id,
                Number = "2213",
                Name = "Грошові документи у національній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "22").Id,
                Number = "2214",
                Name = "Грошові документи в іноземній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "22").Id,
                Number = "2215",
                Name = "Грошові кошти в дорозі у національній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "22").Id,
                Number = "2216",
                Name = "Грошові кошти в дорозі в іноземній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "22").Id,
                Number = "2221",
                Name = "Готівка у національній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "22").Id,
                Number = "2222",
                Name = "Готівка в іноземній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "22").Id,
                Number = "2223",
                Name = "Грошові документи у національній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "22").Id,
                Number = "2224",
                Name = "Грошові документи в іноземній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "22").Id,
                Number = "2225",
                Name = "Грошові кошти в дорозі у національній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "22").Id,
                Number = "2226",
                Name = "Грошові кошти в дорозі в іноземній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "22").Id,
                Number = "2227",
                Name = "Інші еквіваленти грошових коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2311",
                Name = "Поточні рахунки в банку",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2312",
                Name = "Інші поточні рахунки в банку",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2313",
                Name = "Реєстраційні рахунки",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2314",
                Name = "Інші рахунки в Казначействі",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2315",
                Name = "Рахунки для обліку депозитних сум",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2321",
                Name = "Поточні рахунки в банку",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2322",
                Name = "Рахунки для обліку коштів державних цільових фондів у Казначействі",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2323",
                Name = "Реєстраційні рахунки",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2324",
                Name = "Інші рахунки в Казначействі",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2325",
                Name = "Рахунки для обліку депозитних сум",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2331",
                Name = "Кошти державного бюджету на рахунках в установах банків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2332",
                Name = "Кошти державного бюджету на рахунках розпорядників бюджетних коштів, відкритих в установах банків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2333",
                Name = "Кошти державного бюджету на рахунках у Казначействі",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2334",
                Name = "Рахунки для виплати готівки розпорядникам бюджетних коштів за коштами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2335",
                Name = "Депозити державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2341",
                Name = "Кошти місцевих бюджетів на рахунках в установах банків в іноземній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2342",
                Name = "Кошти місцевих бюджетів на рахунках розпорядників бюджетних коштів, відкритих в установах банків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2343",
                Name = "Кошти місцевих бюджетів на рахунках у Казначействі",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2344",
                Name = "Рахунки для виплати готівки розпорядникам бюджетних коштів за коштами місцевого бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2345",
                Name = "Депозити місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2346",
                Name = "Рахунки місцевих бюджетів в установах банків в національній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2351",
                Name = "Інші рахунки для виплати готівки розпорядникам бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2352",
                Name = "Рахунки для виплати готівки державним цільовим фондам",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "23").Id,
                Number = "2353",
                Name = "Рахунки для виплати готівки іншим клієнтам",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "24").Id,
                Number = "2451",
                Name = "Єдиний казначейський рахунок",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "24").Id,
                Number = "2452",
                Name = "Субрахунки єдиного казначейського рахунку",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "25").Id,
                Number = "2511",
                Name = "Придбані акції",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "25").Id,
                Number = "2512",
                Name = "Довгострокові фінансові інвестиції в цінні папери, крім акцій",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "25").Id,
                Number = "2513",
                Name = "Довгострокові фінансові інвестиції в капітал підприємств",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "25").Id,
                Number = "2514",
                Name = "Довгострокові векселі одержані",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "25").Id,
                Number = "2515",
                Name = "Інші фінансові активи розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "25").Id,
                Number = "2521",
                Name = "Придбані акції",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "25").Id,
                Number = "2522",
                Name = "Довгострокові фінансові інвестиції в цінні папери, крім акцій",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "25").Id,
                Number = "2523",
                Name = "Довгострокові фінансові інвестиції в капітал підприємств",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "25").Id,
                Number = "2524",
                Name = "Довгострокові векселі одержані",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "25").Id,
                Number = "2525",
                Name = "Інші фінансові активи державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "25").Id,
                Number = "2531",
                Name = "Придбані акції за рахунок коштів державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "25").Id,
                Number = "2532",
                Name = "Довгострокові цінні папери в активі державного бюджету, крім акцій",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "25").Id,
                Number = "2533",
                Name = "Інші довгострокові фінансові активи державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "25").Id,
                Number = "2541",
                Name = "Придбані акції за рахунок коштів місцевого бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "25").Id,
                Number = "2542",
                Name = "Довгострокові цінні папери в активах місцевих бюджетів, крім акцій",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "25").Id,
                Number = "2543",
                Name = "Інші довгострокові фінансові активи місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "26").Id,
                Number = "2611",
                Name = "Поточні фінансові інвестиції в цінні папери",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "26").Id,
                Number = "2612",
                Name = "Короткострокові векселі одержані",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "26").Id,
                Number = "2613",
                Name = "Інші фінансові активи розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "26").Id,
                Number = "2621",
                Name = "Поточні фінансові інвестиції в цінні папери",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "26").Id,
                Number = "2622",
                Name = "Короткострокові векселі одержані",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "26").Id,
                Number = "2623",
                Name = "Інші фінансові активи державних цільових фондіві",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "26").Id,
                Number = "2631",
                Name = "Короткострокові цінні папери в активі державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "26").Id,
                Number = "2632",
                Name = "Активи державного бюджету за взаємними розрахунками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "26").Id,
                Number = "2633",
                Name = "Активи державного бюджету за взаємними розрахунками з Пенсійним фондом",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "26").Id,
                Number = "2634",
                Name = "Інші короткострокові фінансові активи державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "26").Id,
                Number = "2641",
                Name = "Короткострокові цінні папери в активах місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "26").Id,
                Number = "2642",
                Name = "Активи місцевих бюджетів за взаємними розрахунками з державним бюджетом",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "26").Id,
                Number = "2643",
                Name = "Активи місцевих бюджетів за взаємними розрахунками з місцевими бюджетами інших рівнів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "26").Id,
                Number = "2644",
                Name = "Інші короткострокові фінансові активи місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "27").Id,
                Number = "2711",
                Name = "Дебіторська заборгованість за внутрішніми розрахунками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "27").Id,
                Number = "2721",
                Name = "Дебіторська заборгованість за операціями з переміщення активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "27").Id,
                Number = "2722",
                Name = "Дебіторська заборгованість за внутрішніми розрахунками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "27").Id,
                Number = "2731",
                Name = "Дебіторська заборгованість державного бюджету за операціями з перерахунку доходів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "27").Id,
                Number = "2741",
                Name = "Дебіторська заборгованість місцевих бюджетів за операціями з перерахунку доходів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "27").Id,
                Number = "2751",
                Name = "Рахунок для обліку інших операцій з коштами єдиного казначейського рахунку",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "28").Id,
                Number = "2811",
                Name = "Розрахунки за податковими надходженнями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "28").Id,
                Number = "2812",
                Name = "Розрахунки за неподатковими надходженнями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "28").Id,
                Number = "2813",
                Name = "Розрахунки за іншими надходженнями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "28").Id,
                Number = "2814",
                Name = "Розрахунки за надходженнями єдиного внеску на загальнообов’язкове державне соціальне страхування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "28").Id,
                Number = "2911",
                Name = "Витрати майбутніх періодів розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "28").Id,
                Number = "2921",
                Name = "Витрати майбутніх періодів державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "3130",
                Name = "Надходження до загального фонду державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "3131",
                Name = "Надходження до спеціального фонду державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "3132",
                Name = "Надходження до державного бюджету власних надходжень бюджетних установ",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "3133",
                Name = "Кошти від повернення бюджетних кредитів, наданих за рахунок державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "3134",
                Name = "Надходження від запозичень, приватизації та активних операцій державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "3135",
                Name = "Рахунки для акумулювання надходжень державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "3140",
                Name = "Надходження до загального фонду місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "3141",
                Name = "Надходження до спеціального фонду місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "3142",
                Name = "Надходження до місцевих бюджетів власних надходжень бюджетних установ",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "3143",
                Name = "Кошти від повернення бюджетних кредитів, наданих за рахунок місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "3144",
                Name = "Надходження від запозичень та активних операцій місцевого бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "31").Id,
                Number = "3145",
                Name = "Рахунки для акумулювання надходжень місцевого бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "32").Id,
                Number = "3231",
                Name = "Кошти державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "32").Id,
                Number = "3241",
                Name = "Кошти місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "32").Id,
                Number = "3242",
                Name = "Кошти місцевих бюджетів на рахунках в банках",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "33").Id,
                Number = "3331",
                Name = "Кошти, які підлягають розподілу між державним і місцевими бюджетами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "33").Id,
                Number = "3332",
                Name = "Надходження коштів до державного бюджету, що розподіляються між загальним та спеціальним фондами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "33").Id,
                Number = "3333",
                Name = "Кошти, тимчасово віднесені до надходжень державного бюджету, що підлягають розподілу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "33").Id,
                Number = "3334",
                Name = "Інші кошти, тимчасово віднесені до надходжень державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "33").Id,
                Number = "3335",
                Name = "Кошти, тимчасово віднесені на доходи державного бюджету, що підлягають розподілу між місцевими бюджетами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "33").Id,
                Number = "3341",
                Name = "Кошти, які підлягають розподілу між рівнями бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "33").Id,
                Number = "3342",
                Name = "Кошти, тимчасово віднесені до надходжень місцевих бюджетів, що підлягають розподілу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "33").Id,
                Number = "3342",
                Name = "Інші кошти, тимчасово віднесені до надходжень місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "33").Id,
                Number = "3351",
                Name = "Кошти, які підлягають зарахуванню до надходжень бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3431",
                Name = "Реєстраційні рахунки розпорядників за коштами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3432",
                Name = "Рахунки одержувачів коштів за коштами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3433",
                Name = "Рахунки для обліку операцій по загальнодержавних витратах за коштами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3434",
                Name = "Рахунки для обліку операцій з надання кредитів з державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3435",
                Name = "Рахунки для здійснення витрат з погашення боргу та активних операцій державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3436",
                Name = "Рахунки розпорядників за коштами державного бюджету в установах банків у іноземній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3437",
                Name = "Рахунки розпорядників коштів державного бюджету, відкриті в установах банків в національній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3438",
                Name = "Депозитні рахунки розпорядників коштів державного бюджету, відкриті в установах банків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3440",
                Name = "Особові рахунки розпорядників за коштами, отриманими із місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3441",
                Name = "Особові рахунки розпорядників за коштами, отриманими із місцевого бюджету, на рахунках в банках",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3442",
                Name = "Реєстраційні рахунки розпорядників за коштами місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3443",
                Name = "Рахунки одержувачів коштів за коштами місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3444",
                Name = "Рахунки для обліку операцій з міжбюджетними трансфертами за коштами місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3445",
                Name = "Рахунки для обліку операцій з надання кредитів з місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3446",
                Name = "Рахунки для здійснення витрат з погашення боргу та активних операцій місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3447",
                Name = "Рахунки розпорядників за коштами місцевих бюджетів в установах банків в іноземній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3448",
                Name = "Рахунки розпорядників та одержувачів коштів місцевого бюджету, відкриті в установах банків в національній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "34").Id,
                Number = "3449",
                Name = "Депозитні рахунки розпорядників коштів місцевого бюджету, відкриті в установах банків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "35").Id,
                Number = "3551",
                Name = "Інші рахунки розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "35").Id,
                Number = "3552",
                Name = "Депозитні рахунки розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "35").Id,
                Number = "3553",
                Name = "Рахунки інших клієнтів Казначейства",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "35").Id,
                Number = "3554",
                Name = "Рахунки державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "35").Id,
                Number = "3555",
                Name = "Рахунки для зарахування коштів від приватизації майна",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "35").Id,
                Number = "3556",
                Name = "Рахунки для зарахування єдиного соціального внеску",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "35").Id,
                Number = "3557",
                Name = "Рахунок для обліку коштів органів, що контролюють справляння надходжень бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "35").Id,
                Number = "3558",
                Name = "Рахунки для обліку фінансового резерву",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "36").Id,
                Number = "3651",
                Name = "Нез’ясовані надходження на рахунках в органах Казначейства",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "36").Id,
                Number = "3652",
                Name = "Транзитний рахунок для здійснення операцій з наступною датою валютування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "37").Id,
                Number = "3751",
                Name = "Технічні рахунки Головних управлінь Казначейства",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "37").Id,
                Number = "3752",
                Name = "Рахунки Казначейства за операціями з придбання іноземної валюти",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "37").Id,
                Number = "3753",
                Name = "Внутрішній транзитний рахунок для сум, що не підтверджені отримувачами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "37").Id,
                Number = "3754",
                Name = "Внутрішній транзитний рахунок Рахункової палати Казначейства",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "37").Id,
                Number = "3755",
                Name = "Внутрішній транзитний рахунок для сум, що не підтверджені системою електронних платежів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "37").Id,
                Number = "3756",
                Name = "Внутрішній транзитний рахунок для сум, що не підтверджені у внутрішній платіжній системі Казначейства",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "37").Id,
                Number = "3757",
                Name = "Інші рахунки органів Казначейства",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "38").Id,
                Number = "3850",
                Name = "Рахунки з електронного адміністрування податку на додану вартість",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "38").Id,
                Number = "3851",
                Name = "Рахунки з електронного адміністрування реалізації пального",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "38").Id,
                Number = "3852",
                Name = "Рахунок для обліку коштів бюджетної дотації сільськогосподарським товаровиробникам",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "41").Id,
                Number = "4131",
                Name = "Розрахунки за фінансовими інвестиціями та фінансовими активами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "41").Id,
                Number = "4132",
                Name = "Розрахунки за зобов’язаннями за фінансовими операціями державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "41").Id,
                Number = "4141",
                Name = "Розрахунки за фінансовими інвестиціями та фінансовими активами місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "41").Id,
                Number = "4142",
                Name = "Розрахунки за зобов’язаннями за фінансовими операціями місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "42").Id,
                Number = "4231",
                Name = "Інші розрахунки за коштами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "42").Id,
                Number = "4232",
                Name = "Інші розрахунки з виконання державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "42").Id,
                Number = "4233",
                Name = "Інші внутрішньосистемні розрахунки",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "42").Id,
                Number = "4241",
                Name = "Інші розрахунки за коштами місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "42").Id,
                Number = "4241",
                Name = "Інші розрахунки з виконання місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "42").Id,
                Number = "4251",
                Name = "Внутрішньосистемні розрахунки за операціями у внутрішній платіжній системі Казначейства",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "43").Id,
                Number = "4331",
                Name = "Розрахунки державного бюджету за коштами, які підлягають розподілу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "43").Id,
                Number = "4341",
                Name = "Розрахунки місцевих бюджетів за коштами, які підлягають розподілу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "43").Id,
                Number = "4351",
                Name = "Розрахунки за надходженнями єдиного внеску на загальнообов’язкове державне соціальне страхування, які підлягають розподілу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "44").Id,
                Number = "4431",
                Name = "Позиція Казначейства щодо іноземної валюти державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "44").Id,
                Number = "4432",
                Name = "Еквівалент позиції Казначейства щодо іноземної валюти державного бюджету (контррахунок)",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "44").Id,
                Number = "4441",
                Name = "Позиція Казначейства щодо іноземної валюти місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "44").Id,
                Number = "4442",
                Name = "Еквівалент позиції Казначейства щодо іноземної валюти місцевих бюджетів (контррахунок)",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "45").Id,
                Number = "4531",
                Name = "Рахунок для обліку надходжень, які підлягають розподілу між державним і місцевими бюджетами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "45").Id,
                Number = "4532",
                Name = "Рахунок для обліку надходжень державного бюджету, які розподіляються між загальним і спеціальним фондами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "45").Id,
                Number = "4533",
                Name = "Рахунок для обліку коштів, тимчасово віднесених до надходжень державного бюджету, які підлягають розподілу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "45").Id,
                Number = "4534",
                Name = "Рахунок для обліку інших коштів, тимчасово віднесених до надходжень державного бюджету, які підлягають розподілу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "45").Id,
                Number = "4535",
                Name = "Кошти, тимчасово віднесені на доходи державного бюджету, що підлягають розподілу між місцевими бюджетами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "45").Id,
                Number = "4541",
                Name = "Рахунок для обліку надходжень, які підлягають розподілу між рівнями місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "45").Id,
                Number = "4542",
                Name = "Рахунок для обліку коштів, тимчасово віднесених до надходжень місцевих бюджетів, які підлягають розподілу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "45").Id,
                Number = "4543",
                Name = "Рахунок для обліку інших коштів, тимчасово віднесених до надходжень місцевих бюджетів, які підлягають розподілу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "45").Id,
                Number = "4551",
                Name = "Рахунок для обліку надходжень єдиного внеску на загальнообов’язкове державне соціальне страхування, які підлягають розподілу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "46").Id,
                Number = "4651",
                Name = "Технічний рахунок",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "51").Id,
                Number = "5111",
                Name = "Внесений капітал розпорядникам бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "51").Id,
                Number = "5121",
                Name = "Внесений капітал державним цільовим фондам",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "52").Id,
                Number = "5211",
                Name = "Капітал у підприємствах у формі акцій",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "52").Id,
                Number = "5212",
                Name = "Капітал у підприємствах в іншій формі участі у капіталі",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "52").Id,
                Number = "5213",
                Name = "Капітал у частках (паях)",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "52").Id,
                Number = "5221",
                Name = "Капітал у підприємствах у формі акцій",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "52").Id,
                Number = "5222",
                Name = "Капітал у підприємствах в іншій формі участі у капіталі",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "52").Id,
                Number = "5223",
                Name = "Капітал у частках (паях)",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "53").Id,
                Number = "5311",
                Name = "Дооцінка (уцінка) необоротних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "53").Id,
                Number = "5312",
                Name = "Дооцінка (уцінка) інших активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "53").Id,
                Number = "5321",
                Name = "Дооцінка (уцінка) необоротних активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "53").Id,
                Number = "5322",
                Name = "Дооцінка (уцінка) інших активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "54").Id,
                Number = "5411",
                Name = "Цільове фінансування розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "54").Id,
                Number = "5421",
                Name = "Цільове фінансування державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "55").Id,
                Number = "5511",
                Name = "Фінансові результати виконання кошторису звітного періоду",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "55").Id,
                Number = "5512",
                Name = "Накопичені фінансові результати виконання кошторису",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "55").Id,
                Number = "5521",
                Name = "Фінансовий результат виконання бюджету (кошторису) звітного періоду",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "55").Id,
                Number = "5522",
                Name = "Накопичені фінансові результати виконання бюджету (кошторису)",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "55").Id,
                Number = "5531",
                Name = "Результат виконання державного бюджету звітного періоду",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "55").Id,
                Number = "5532",
                Name = "Накопичені фінансові результати виконання державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "55").Id,
                Number = "5541",
                Name = "Результат виконання місцевих бюджетів звітного періоду",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "55").Id,
                Number = "5542",
                Name = "Накопичені фінансові результати виконання місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "56").Id,
                Number = "5621",
                Name = "Резервний капітал державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6011",
                Name = "Довгострокові кредити банків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6012",
                Name = "Відстрочені довгострокові кредити банків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6013",
                Name = "Інші довгострокові позики",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6014",
                Name = "Зобов’язання за довгостроковими цінними паперами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6015",
                Name = "Довгострокові зобов’язання за операціями з оренди",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6016",
                Name = "Інші довгострокові фінансові зобов’язання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6021",
                Name = "Довгострокові кредити банків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6022",
                Name = "Відстрочені довгострокові кредити банків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6023",
                Name = "Інші довгострокові позики",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6024",
                Name = "Зобов’язання за довгостроковими цінними паперами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6025",
                Name = "Довгострокові зобов’язання за операціями з оренди",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6026",
                Name = "Інші довгострокові фінансові зобов’язання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6031",
                Name = "Внутрішні зобов’язання за довгостроковими цінними паперами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6032",
                Name = "Зовнішні зобов’язання за довгостроковими цінними паперами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6033",
                Name = "Довгострокові внутрішні кредити, залучені до державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6034",
                Name = "Довгострокові зовнішні кредити, залучені до державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6035",
                Name = "Інші довгострокові внутрішні зобов’язання державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6036",
                Name = "Інші довгострокові зовнішні зобов’язання державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6041",
                Name = "Зобов’язання за довгостроковими цінними паперами місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6042",
                Name = "Довгострокові внутрішні кредити, залучені до місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6043",
                Name = "Довгострокові зовнішні кредити, залучені до місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6044",
                Name = "Інші довгострокові внутрішні зобов’язання місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "60").Id,
                Number = "6045",
                Name = "Інші довгострокові зовнішні зобов’язання місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6111",
                Name = "Поточна заборгованість за довгостроковими кредитами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6112",
                Name = "Поточна заборгованість за зобов’язаннями за довгостроковими цінними паперами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6113",
                Name = "Поточна заборгованість за іншими довгостроковими зобов’язаннями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6114",
                Name = "Короткострокові кредити банків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6115",
                Name = "Відстрочені короткострокові кредити банків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6116",
                Name = "Короткострокові позики",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6117",
                Name = "Інші короткострокові фінансові зобов’язання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6121",
                Name = "Поточна заборгованість за довгостроковими кредитами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6122",
                Name = "Поточна заборгованість за зобов’язаннями за довгостроковими цінними паперами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6123",
                Name = "Поточна заборгованість за іншими довгостроковими зобов’язаннями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6124",
                Name = "Короткострокові кредити банків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6125",
                Name = "Відстрочені короткострокові кредити банків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6126",
                Name = "Короткострокові позики",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6127",
                Name = "Інші короткострокові фінансові зобов’язання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6130",
                Name = "Поточна заборгованість за внутрішніми зобов’язаннями за довгостроковими цінними паперами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6131",
                Name = "Поточна заборгованість за зовнішніми зобов’язаннями за довгостроковими цінними паперами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6132",
                Name = "Поточна заборгованість за довгостроковими внутрішніми кредитами, залученими до державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6133",
                Name = "Поточна заборгованість за довгостроковими зовнішніми кредитами, залученими до державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6134",
                Name = "Поточна заборгованість за іншими довгостроковими внутрішніми зобов’язаннями державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6135",
                Name = "Поточна заборгованість за іншими довгостроковими зовнішніми зобов’язаннями державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6136",
                Name = "Короткострокові внутрішні кредити, залучені до державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6137",
                Name = "Короткострокові зовнішні кредити, залучені до державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6138",
                Name = "Інші поточні внутрішні зобов’язання за позиками державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6139",
                Name = "Інші поточні зовнішні зобов’язання за позиками державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6141",
                Name = "Поточна заборгованість за зобов’язаннями за довгостроковими цінними паперами місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6142",
                Name = "Поточна заборгованість за довгостроковими внутрішніми кредитами, залученими до місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6143",
                Name = "Поточна заборгованість за довгостроковими зовнішніми кредитами,залученими до місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6144",
                Name = "Поточна заборгованість за іншими довгостроковими внутрішніми зобов’язаннями місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6145",
                Name = "Поточна заборгованість за іншими довгостроковими зовнішніми зобов’язаннями місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6146",
                Name = "Короткострокові внутрішні кредити, залучені до місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6147",
                Name = "Короткострокові зовнішні кредити, залучені до місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6148",
                Name = "Інші поточні внутрішні зобов’язання за позиками місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "61").Id,
                Number = "6149",
                Name = "Інші поточні зовнішні зобов’язання за позиками місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "62").Id,
                Number = "6211",
                Name = "Розрахунки з постачальниками та підрядниками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "62").Id,
                Number = "6212",
                Name = "Розрахунки із замовниками за роботи і послуги",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "62").Id,
                Number = "6213",
                Name = "Розрахунки із замовниками за науково-дослідні роботи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "62").Id,
                Number = "6214",
                Name = "Розрахунки за одержаними авансами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "62").Id,
                Number = "6221",
                Name = "Розрахунки з постачальниками та підрядниками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "62").Id,
                Number = "6222",
                Name = "Розрахунки із замовниками за роботи і послуги",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "62").Id,
                Number = "6223",
                Name = "Розрахунки із замовниками за науково-дослідні роботи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "62").Id,
                Number = "6224",
                Name = "Розрахунки за одержаними авансами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "63").Id,
                Number = "6311",
                Name = "Розрахунки з бюджетом за податками і зборами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "63").Id,
                Number = "6312",
                Name = "Інші розрахунки з бюджетом",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "63").Id,
                Number = "6313",
                Name = "Розрахунки із загальнообов’язкового державного соціального страхування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "63").Id,
                Number = "6321",
                Name = "Розрахунки з бюджетом за податками і зборами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "63").Id,
                Number = "6322",
                Name = "Інші розрахунки з бюджетом",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "63").Id,
                Number = "6323",
                Name = "Розрахунки із загальнообов’язкового державного соціального страхування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6411",
                Name = "Поточні зобов’язання за цінними паперами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6412",
                Name = "Розрахунки з депонентами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6413",
                Name = "Розрахунки за депозитними сумами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6414",
                Name = "Розрахунки за спеціальними видами платежів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6415",
                Name = "Розрахунки з іншими кредиторами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6416",
                Name = "Розрахунки за страхуванням",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6417",
                Name = "Розрахунки за зобов’язаннями зі спільної діяльності",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6421",
                Name = "Поточні зобов’язання за цінними паперами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6422",
                Name = "Розрахунки з депонентами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6423",
                Name = "Розрахунки за депозитними сумами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6424",
                Name = "Розрахунки за спеціальними видами платежів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6425",
                Name = "Розрахунки з іншими кредиторами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6426",
                Name = "Розрахунки за страхуванням",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6427",
                Name = "Розрахунки за зобов’язаннями зі спільної діяльності",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6431",
                Name = "Депозити, отримані до державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6432",
                Name = "Короткострокові внутрішні зобов’язання за цінними паперами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6433",
                Name = "Короткострокові зовнішні зобов’язання за цінними паперами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6434",
                Name = "Середньострокові внутрішні зобов’язання за цінними паперами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6435",
                Name = "Середньострокові зовнішні зобов’язання за цінними паперами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6441",
                Name = "Депозити, отримані до місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6442",
                Name = "Короткострокові зобов’язання за цінними паперами місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "64").Id,
                Number = "6443",
                Name = "Середньострокові зобов’язання за цінними паперами місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6511",
                Name = "Розрахунки із заробітної плати",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6512",
                Name = "Розрахунки з виплати стипендій, пенсій, допомоги та інших трансфертів населенню",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6513",
                Name = "Розрахунки з працівниками за товари, продані в кредит",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6514",
                Name = "Розрахунки з працівниками за безготівковими перерахуваннями на рахунки з вкладів у банках",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6515",
                Name = "Розрахунки з працівниками за безготівковими перерахуваннями внесків за договорами добровільного страхування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6516",
                Name = "Розрахунки з членами профспілки за безготівковими перерахуваннями сум членських профспілкових внесків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6517",
                Name = "Розрахунки з працівниками за позиками банків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6518",
                Name = "Розрахунки за виконавчими документами та інші утримання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6519",
                Name = "Інші розрахунки за виконані роботи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6521",
                Name = "Розрахунки із заробітної плати",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6522",
                Name = "Розрахунки з виплати пенсій, допомоги та інших трансфертів населенню",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6523",
                Name = "Розрахунки з працівниками за товари, продані в кредит",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6524",
                Name = "Розрахунки з працівниками за безготівковими перерахуваннями на рахунки з вкладів у банках",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6525",
                Name = "Розрахунки з працівниками за безготівковими перерахуваннями внесків за договорами добровільного страхування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6526",
                Name = "Розрахунки з членами профспілки за безготівковими перерахуваннями сум членських профспілкових внесків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6527",
                Name = "Розрахунки з працівниками за позиками банків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6528",
                Name = "Розрахунки за виконавчими документами та інші утримання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "65").Id,
                Number = "6529",
                Name = "Інші розрахунки за виконані роботи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "66").Id,
                Number = "6611",
                Name = "Зобов’язання за внутрішніми розрахунками розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "66").Id,
                Number = "6621",
                Name = "Зобов’язання за внутрішніми розрахунками за операціями з переміщення активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "66").Id,
                Number = "6622",
                Name = "Зобов’язання за внутрішніми розрахунками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "66").Id,
                Number = "6631",
                Name = "Зобов’язання державного бюджету за взаємними розрахунками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "66").Id,
                Number = "6641",
                Name = "Зобов’язання місцевих бюджетів за взаємними розрахунками",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "66").Id,
                Number = "6642",
                Name = "Зобов’язання місцевих бюджетів за короткостроковими позиками, отриманими з єдиного казначейського рахунку",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "66").Id,
                Number = "6643",
                Name = "Зобов’язання місцевих бюджетів за середньостроковими позиками, отриманими з єдиного казначейського рахунку",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "66").Id,
                Number = "6651",
                Name = "Зобов’язання за іншими коштами перед органами Казначейства",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "67").Id,
                Number = "6711",
                Name = "Довгострокові забезпечення майбутніх витрат і платежів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "67").Id,
                Number = "6712",
                Name = "Поточні забезпечення майбутніх витрат і платежів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "67").Id,
                Number = "6721",
                Name = "Довгострокові забезпечення майбутніх витрат і платежів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "67").Id,
                Number = "6722",
                Name = "Поточні забезпечення майбутніх витрат і платежів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "68").Id,
                Number = "6811",
                Name = "Зобов’язання за податковими надходженнями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "68").Id,
                Number = "6812",
                Name = "Зобов’язання за неподатковими надходженнями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "68").Id,
                Number = "6813",
                Name = "Зобов’язання за іншими надходженнями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "68").Id,
                Number = "6814",
                Name = "Зобов’язання за коштами, які підлягають розподілу за видами загальнообов’язкового державного соціального страхування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "69").Id,
                Number = "6911",
                Name = "Доходи майбутніх періодів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "69").Id,
                Number = "6921",
                Name = "Доходи майбутніх періодів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "70").Id,
                Number = "7011",
                Name = "Бюджетні асигнування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "70").Id,
                Number = "7021",
                Name = "Асигнування державних цільових фондів на утримання апарату",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "71").Id,
                Number = "7111",
                Name = "Доходи від реалізації продукції (робіт, послуг)",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "71").Id,
                Number = "7112",
                Name = "Дохід від оприбуткування активів, раніше не врахованих в балансі",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "71").Id,
                Number = "7121",
                Name = "Доходи від реалізації продукції (робіт, послуг)",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "71").Id,
                Number = "7122",
                Name = "Дохід від оприбуткування активів, раніше не врахованих в балансі",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "71").Id,
                Number = "7131",
                Name = "Доходи державного бюджету від наданих послуг",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "71").Id,
                Number = "7141",
                Name = "Доходи місцевого бюджету від наданих послуг",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "72").Id,
                Number = "7211",
                Name = "Дохід від реалізації активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "72").Id,
                Number = "7221",
                Name = "Дохід від реалізації активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "72").Id,
                Number = "7231",
                Name = "Доходи державного бюджету від продажу майна",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "72").Id,
                Number = "7241",
                Name = "Доходи місцевого бюджету від продажу майна",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "73").Id,
                Number = "7311",
                Name = "Фінансові доходи розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "73").Id,
                Number = "7321",
                Name = "Фінансові доходи державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "73").Id,
                Number = "7331",
                Name = "Фінансові доходи державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "73").Id,
                Number = "7341",
                Name = "Фінансові доходи місцевого бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "74").Id,
                Number = "7411",
                Name = "Інші доходи за обмінними операціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "74").Id,
                Number = "7421",
                Name = "Інші доходи за обмінними операціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "74").Id,
                Number = "7431",
                Name = "Інші доходи за обмінними операціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "74").Id,
                Number = "7441",
                Name = "Інші доходи за обмінними операціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "75").Id,
                Number = "7511",
                Name = "Доходи за необмінними операціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "75").Id,
                Number = "7512",
                Name = "Трансферти",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "75").Id,
                Number = "7521",
                Name = "Надходження єдиного внеску на загальнообов’язкове державне соціальне страхування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "75").Id,
                Number = "7522",
                Name = "Трансферти",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "75").Id,
                Number = "7523",
                Name = "Інші надходження",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "75").Id,
                Number = "7531",
                Name = "Податкові надходження",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "75").Id,
                Number = "7532",
                Name = "Неподаткові надходження",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "75").Id,
                Number = "7533",
                Name = "Трансферти",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "75").Id,
                Number = "7534",
                Name = "Інші доходи за необмінними операціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "75").Id,
                Number = "7541",
                Name = "Податкові надходження",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "75").Id,
                Number = "7542",
                Name = "Неподаткові надходження",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "75").Id,
                Number = "7543",
                Name = "Трансферти",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "75").Id,
                Number = "7544",
                Name = "Інші доходи за необмінними операціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "76").Id,
                Number = "7631",
                Name = "Надходження до державного бюджету від повернення бюджетних кредитів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "76").Id,
                Number = "7632",
                Name = "Надходження до державного бюджету від операцій з фінансування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "76").Id,
                Number = "7641",
                Name = "Надходження до місцевих бюджетів від повернення бюджетних кредитів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "76").Id,
                Number = "7642",
                Name = "Надходження до місцевих бюджетів від операцій з фінансування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "8011",
                Name = "Витрати на оплату праці",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "8012",
                Name = "Відрахування на соціальні заходи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "8013",
                Name = "Матеріальні витрати",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "8014",
                Name = "Амортизація",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "8021",
                Name = "Витрати на оплату праці",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "8022",
                Name = "Відрахування на соціальні заходи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "8023",
                Name = "Матеріальні витрати",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "8024",
                Name = "Амортизація",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "8031",
                Name = "Витрати на оплату праці",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "8032",
                Name = "Відрахування на соціальні заходи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "8033",
                Name = "Матеріальні витрати",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "8041",
                Name = "Витрати на оплату праці",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "8042",
                Name = "Відрахування на соціальні заходи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "80").Id,
                Number = "8043",
                Name = "Матеріальні витрати",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "81").Id,
                Number = "8111",
                Name = "Витрати на оплату праці",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "81").Id,
                Number = "8112",
                Name = "Відрахування на соціальні заходи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "81").Id,
                Number = "8113",
                Name = "Матеріальні витрати",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "81").Id,
                Number = "8114",
                Name = "Амортизація",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "81").Id,
                Number = "8115",
                Name = "Інші витрати",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "81").Id,
                Number = "8121",
                Name = "Витрати на оплату праці",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "81").Id,
                Number = "8122",
                Name = "Відрахування на соціальні заходи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "81").Id,
                Number = "8123",
                Name = "Матеріальні витрати",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "81").Id,
                Number = "8124",
                Name = "Амортизація",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "81").Id,
                Number = "8125",
                Name = "Інші витрати",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "82").Id,
                Number = "8211",
                Name = "Собівартість проданих активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "82").Id,
                Number = "8212",
                Name = "Витрати, пов’язані з реалізацією майна",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "82").Id,
                Number = "8221",
                Name = "Собівартість проданих активів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "82").Id,
                Number = "8222",
                Name = "Витрати, пов’язані з реалізацією майна",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "83").Id,
                Number = "8311",
                Name = "Фінансові витрати",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "83").Id,
                Number = "8321",
                Name = "Фінансові витрати",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "83").Id,
                Number = "8331",
                Name = "Фінансові витрати державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "83").Id,
                Number = "8341",
                Name = "Фінансові витрати місцевого бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "84").Id,
                Number = "8411",
                Name = "Інші витрати за обмінними операціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "84").Id,
                Number = "8421",
                Name = "Інші витрати за обмінними операціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "84").Id,
                Number = "8431",
                Name = "Інші витрати за обмінними операціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "84").Id,
                Number = "8441",
                Name = "Інші витрати за обмінними операціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "85").Id,
                Number = "8511",
                Name = "Витрати за необмінними операціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "85").Id,
                Number = "8521",
                Name = "Витрати на утримання апарату фонду",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "85").Id,
                Number = "8522",
                Name = "Витрати на державне соціальне страхування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "85").Id,
                Number = "8523",
                Name = "Трансферти",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "85").Id,
                Number = "8524",
                Name = "Інші витрати за необмінними операціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "85").Id,
                Number = "8531",
                Name = "Трансферти",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "85").Id,
                Number = "8532",
                Name = "Інші витрати за необмінними операціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "85").Id,
                Number = "8541",
                Name = "Трансферти",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "85").Id,
                Number = "8542",
                Name = "Інші витрати за необмінними операціями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "86").Id,
                Number = "8631",
                Name = "Витрати державного бюджету за операціями з надання кредитів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "86").Id,
                Number = "8632",
                Name = "Витрати державного бюджету за операціями з фінансування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "86").Id,
                Number = "8641",
                Name = "Витрати місцевих бюджетів за операціями з надання кредитів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "86").Id,
                Number = "8642",
                Name = "Витрати місцевих бюджетів за операціями з фінансування",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "86").Id,
                Number = "8643",
                Name = "Надання кредитів із спеціального фонду місцевого бюджету з рахунків, відкритих в банках в національній валюті",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "90").Id,
                Number = "9011",
                Name = "Відкриті асигнування за узагальненими показниками державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "90").Id,
                Number = "9012",
                Name = "Відкриті асигнування на виконання програм державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "90").Id,
                Number = "9013",
                Name = "Відкриті асигнування державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "90").Id,
                Number = "9021",
                Name = "Пропозиції про відкриття асигнувань загального фонду державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "90").Id,
                Number = "9031",
                Name = "Ліміти органів Казначейства для здійснення платежів за витратами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9121",
                Name = "Асигнування державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9130",
                Name = "Затверджені зведені бюджетні асигнування державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9131",
                Name = "Затверджені бюджетні асигнування державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9132",
                Name = "Поточні зведені бюджетні асигнування державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9133",
                Name = "Поточні бюджетні асигнування державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9134",
                Name = "Затверджені зведені помісячні бюджетні асигнування державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9135",
                Name = "Затверджені помісячні бюджетні асигнування державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9136",
                Name = "Поточні зведені помісячні бюджетні асигнування державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9137",
                Name = "Поточні помісячні бюджетні асигнування державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9138",
                Name = "Зведення показників спеціального фонду",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9141",
                Name = "Затверджені зведені бюджетні асигнування місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9142",
                Name = "Затверджені бюджетні асигнування місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9143",
                Name = "Поточні зведені бюджетні асигнування місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9144",
                Name = "Поточні бюджетні асигнування місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9145",
                Name = "Затверджені зведені помісячні бюджетні асигнування місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9146",
                Name = "Затверджені помісячні бюджетні асигнування місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9147",
                Name = "Поточні зведені помісячні бюджетні асигнування місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9148",
                Name = "Поточні помісячні бюджетні асигнування місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9151",
                Name = "Асигнування на взяття зобов'язань за коштами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9152",
                Name = "Асигнування спеціального фонду державного бюджету на взяття бюджетних фінансових зобов’язань",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9161",
                Name = "Асигнування на взяття зобов'язань за коштами місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "91").Id,
                Number = "9162",
                Name = "Асигнування спеціального фонду місцевого бюджету на взяття бюджетних фінансових зобов’язань",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9201",
                Name = "Затверджений розпис доходів державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9202",
                Name = "Поточний розпис доходів державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9203",
                Name = "Затверджений помісячний розпис доходів державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9204",
                Name = "Поточний помісячний розпис доходів державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9211",
                Name = "Затверджений розпис фінансування державного бюджету за типом боргового зобов'язання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9212",
                Name = "Поточний розпис фінансування державного бюджету за типом боргового зобов'язання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9213",
                Name = "Затверджений помісячний розпис фінансування державного бюджету за типом боргового зобов'язання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9214",
                Name = "Поточний помісячний розпис фінансування державного бюджету за типом боргового зобов’язання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9221",
                Name = "Затверджений розпис повернення кредитів до державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9222",
                Name = "Поточний розпис повернення кредитів до державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9223",
                Name = "Затверджений помісячний розпис повернення кредитів до державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9224",
                Name = "Поточний помісячний розпис повернення кредитів до державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9231",
                Name = "Затверджений зведений розпис асигнувань державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9232",
                Name = "Затверджений розпис асигнувань державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9233",
                Name = "Поточний зведений розпис асигнувань державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9234",
                Name = "Поточний розпис асигнувань державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9235",
                Name = "Затверджений зведений помісячний розпис асигнувань державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9236",
                Name = "Затверджений помісячний розпис асигнувань державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9237",
                Name = "Поточний зведений помісячний розпис асигнувань державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9238",
                Name = "Поточний помісячний розпис асигнувань державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9241",
                Name = "Затверджений розпис витрат спеціального фонду державного бюджету з розподілом за видами надходжень",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9242",
                Name = "Затверджений помісячний розпис витрат спеціального фонду державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9251",
                Name = "Затверджені узагальнені бюджетні призначення головних розпорядників бюджетних коштів за коштами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9252",
                Name = "Поточні узагальнені бюджетні призначення головних розпорядників бюджетних коштів за коштами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9253",
                Name = "Затверджені узагальнені помісячні бюджетні призначення головних розпорядників бюджетних коштів за коштами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9254",
                Name = "Поточні узагальнені помісячні бюджетні призначення головних розпорядників бюджетних коштів за коштами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9261",
                Name = "Затверджений розпис доходів місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9262",
                Name = "Поточний розпис доходів місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9263",
                Name = "Затверджений помісячний розпис доходів місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9264",
                Name = "Поточний помісячний розпис доходів місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9271",
                Name = "Затверджений розпис фінансування місцевих бюджетів за типом боргового зобов'язання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9272",
                Name = "Поточний розпис фінансування місцевих бюджетів за типом боргового зобов'язання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9273",
                Name = "Затверджений помісячний розпис фінансування місцевих бюджетів за типом боргового зобов'язання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9274",
                Name = "Поточний помісячний розпис фінансування місцевих бюджетів за типом боргового зобов’язання",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9281",
                Name = "Затверджений розпис повернення кредитів до місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9282",
                Name = "Поточний розпис повернення кредитів до місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9283",
                Name = "Затверджений помісячний розпис повернення кредитів до місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9284",
                Name = "Поточний помісячний розпис повернення кредитів до місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9291",
                Name = "Затверджений зведений розпис асигнувань місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9292",
                Name = "Затверджений розпис асигнувань місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9293",
                Name = "Поточний зведений розпис асигнувань місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9294",
                Name = "Поточний розпис асигнувань місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9295",
                Name = "Затверджений зведений помісячний розпис асигнувань місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9296",
                Name = "Затверджений помісячний розпис асигнувань місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9297",
                Name = "Поточний зведений помісячний розпис асигнувань місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "92").Id,
                Number = "9298",
                Name = "Поточний помісячний розпис асигнувань місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "93").Id,
                Number = "9331",
                Name = "Бюджетні зобов’язання розпорядників та одержувачів бюджетних коштів за коштами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "93").Id,
                Number = "9332",
                Name = "Бюджетні фінансові зобов’язання розпорядників та одержувачів бюджетних коштів за коштами державного бюджету звітного періоду",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "93").Id,
                Number = "9333",
                Name = "Бюджетні фінансові зобов’язання розпорядників та одержувачів бюджетних коштів за попередньою оплатою та авансовими платежами з державного бюджету звітного періоду",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "93").Id,
                Number = "9334",
                Name = "Бюджетні фінансові зобов’язання розпорядників та одержувачів бюджетних коштів за коштами державного бюджету минулих бюджетних періодів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "93").Id,
                Number = "9335",
                Name = "Довгострокові бюджетні зобов’язання за коштами державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "93").Id,
                Number = "9341",
                Name = "Бюджетні зобов’язання розпорядників та одержувачів бюджетних коштів за коштами місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "93").Id,
                Number = "9342",
                Name = "Бюджетні фінансові зобов’язання розпорядників та одержувачів бюджетних коштів за коштами місцевих бюджетів звітного періоду",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "93").Id,
                Number = "9343",
                Name = "Бюджетні фінансові зобов’язання розпорядників та одержувачів бюджетних коштів за попередньою оплатою та авансовими платежами з місцевих бюджетів звітного періоду",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "93").Id,
                Number = "9344",
                Name = "Бюджетні фінансові зобов’язання розпорядників та одержувачів бюджетних коштів за коштами місцевих бюджетів минулих бюджетних періодів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "93").Id,
                Number = "9351",
                Name = "Розрахункові документи за узгодженими податковими зобов’язаннями платника податку",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "9431",
                Name = "Нараховані відсотки за кредитами (позиками), наданими з державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "9432",
                Name = "Нараховані відсотки за кредитами (позиками), залученими державою та під державні гарантії",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "9433",
                Name = "Нарахована плата за надання державних гарантій і кредитів (позик), залучених державою",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "9434",
                Name = "Нараховані штрафні санкції за кредитами, наданими з державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "9435",
                Name = "Нараховані штрафні санкції за кредитами (позиками), залученими державою та під державні гарантії",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "9441",
                Name = "Нараховані відсотки за кредитами (позиками), наданими з місцевого бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "9442",
                Name = "Нараховані відсотки за кредитами (позиками), залученими місцевими бюджетами та/або під місцеві гарантії",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "9443",
                Name = "Нарахована плата за надання місцевих гарантій та надання кредитів за рахунок коштів, залучених місцевими бюджетами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "9444",
                Name = "Нараховані штрафні санкції за кредитами, наданими з місцевого бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "9445",
                Name = "Нараховані штрафні санкції за кредитами (позиками), залученими місцевими бюджетами та/або під місцеві гарантії",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "94").Id,
                Number = "9451",
                Name = "Нараховані доходи фінансового резерву",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "95").Id,
                Number = "9531",
                Name = "Боргові зобов’язання суб’єктів господарювання щодо кредитів (позик), виконання яких забезпечено державними гарантіями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "95").Id,
                Number = "9532",
                Name = "Боргові зобов’язання суб’єктів господарювання щодо іноземних кредитів (позик), виконання яких забезпечено державними гарантіями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "95").Id,
                Number = "9533",
                Name = "Нараховані відсотки за користування кредитами, залученими державою",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "95").Id,
                Number = "9534",
                Name = "Комісії та/або інші платежі з обслуговування державного боргу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "95").Id,
                Number = "9535",
                Name = "Нараховані відсотки за цінними паперами держави",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "95").Id,
                Number = "9536",
                Name = "Премії, що надходять до державного бюджету від розміщення державних цінних паперів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "95").Id,
                Number = "9537",
                Name = "Дисконт при розміщенні дисконтних державних цінних паперів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "95").Id,
                Number = "9538",
                Name = "Дисконт при погашенні дисконтних державних цінних паперів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "95").Id,
                Number = "9541",
                Name = "Боргові зобов’язання суб’єктів господарювання щодо кредитів (позик), виконання яких забезпечено місцевими гарантіями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "95").Id,
                Number = "9542",
                Name = "Боргові зобов’язання суб’єктів господарювання щодо іноземних кредитів (позик), виконання яких забезпечено місцевими гарантіями",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "95").Id,
                Number = "9543",
                Name = "Платежі з обслуговування місцевого боргу",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "9631",
                Name = "Емітовані короткострокові облігації внутрішньої державної позики",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "9632",
                Name = "Емітовані середньострокові облігації внутрішньої державної позики",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "9633",
                Name = "Емітовані довгострокові облігації внутрішньої державної позики",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "9634",
                Name = "Емітовані інші внутрішні цінні папери державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "9635",
                Name = "Емітовані короткострокові облігації зовнішньої державної позики",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "9636",
                Name = "Емітовані середньострокові облігації зовнішньої державної позики",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "9637",
                Name = "Емітовані довгострокові облігації зовнішньої державної позики",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "9638",
                Name = "Емітовані інші зовнішні цінні папери державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "9641",
                Name = "Емітовані короткострокові облігації місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "9642",
                Name = "Емітовані середньострокові облігації місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "9643",
                Name = "Емітовані довгострокові облігації місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "9644",
                Name = "Емітовані інші цінні папери місцевих бюджетів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "9651",
                Name = "Фінансові казначейські векселі",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "96").Id,
                Number = "9661",
                Name = "Державні деривативи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "9711",
                Name = "Рахунок для обліку коштів державного бюджету, отриманих розпорядниками (одержувачами) бюджетних коштів на здійснення видатків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "9712",
                Name = "Рахунок для обліку коштів державного бюджету, що надійшли на відновлення касових видатків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "9713",
                Name = "Розрахунки за асигнуваннями державного бюджету, отримані розпорядниками (одержувачами) бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "9714",
                Name = "Рахунок для обліку курсової різниці розпорядників коштів державного бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "9721",
                Name = "Рахунок для обліку коштів державного бюджету, отриманих",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "9722",
                Name = "Рахунок для обліку коштів, отриманих як підкріплення для здійснення повернення надходжень",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "9723",
                Name = "Розрахунки за коштами державного бюджету, отримані",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "9731",
                Name = "Рахунок для обліку коштів місцевих бюджетів, отриманих розпорядниками (одержувачами) бюджетних коштів на здійснення видатків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "9732",
                Name = "Рахунок для обліку курсової різниці розпорядників коштів місцевого бюджету",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "9741",
                Name = "Рахунок для обліку коштів, отриманих державними цільовими фондами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "9742",
                Name = "Рахунок для обліку коштів, отриманих державними цільовими фондами від вищестоящих органів Казначейства",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "9743",
                Name = "Рахунок для обліку коштів, отриманих державними цільовими фондами від вищестоящих органів Казначейства",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "97").Id,
                Number = "9744",
                Name = "Рахунок для обліку коштів, які підлягають розподілу за видами загальнообов'язкового державного соціального страхування, отримані",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "98").Id,
                Number = "9811",
                Name = "Рахунок для обліку асигнувань державного бюджету, переданих розпорядниками бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "98").Id,
                Number = "9812",
                Name = "Рахунок для обліку асигнувань державного бюджету, переданих розпорядниками бюджетних коштів, що обслуговуються базовими органами Казначейства",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "98").Id,
                Number = "9813",
                Name = "Розрахунки за асигнуваннями державного бюджету, передані розпорядниками бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "98").Id,
                Number = "9821",
                Name = "Рахунок для обліку коштів державного бюджету, переданих",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "98").Id,
                Number = "9822",
                Name = "Рахунок для обліку коштів, переданих як підкріплення для здійснення повернення надходжень",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "98").Id,
                Number = "9823",
                Name = "Розрахунки за коштами державного бюджету, переданіь",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "98").Id,
                Number = "9831",
                Name = "Рахунок для обліку коштів місцевих бюджетів, переданих розпорядниками бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "98").Id,
                Number = "9841",
                Name = "Рахунок для обліку коштів, переданих органами Казначейства з державного бюджету місцевим бюджетам",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "98").Id,
                Number = "9842",
                Name = "Рахунок для обліку коштів, переданих з місцевого бюджету іншим місцевим бюджетам за міжбюджетними трансфертами",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "98").Id,
                Number = "9851",
                Name = "Рахунок для обліку коштів державних цільових фондів, направлених на здійснення видатків",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "98").Id,
                Number = "9852",
                Name = "Рахунок для обліку коштів, переданих державними цільовими фондами вищестоящим органам Казначейства",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "98").Id,
                Number = "9853",
                Name = "Рахунок для обліку коштів, переданих державними цільовими фондами нижчестоящим органам Казначейства",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "98").Id,
                Number = "9854",
                Name = "Рахунок для обліку коштів, які підлягають розподілу за видами загальнообов'язкового державного соціального страхування, переданих",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "99").Id,
                Number = "9911",
                Name = "Контррахунок для активних рахунків позабалансового обліку",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "99").Id,
                Number = "9921",
                Name = "Контррахунок для пасивних рахунків позабалансового обліку",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "01").Id,
                Number = "011",
                Name = "Орендовані основні засоби розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "01").Id,
                Number = "012",
                Name = "Орендовані основні засоби державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "01").Id,
                Number = "013",
                Name = "Орендовані нематеріальні активи розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "01").Id,
                Number = "014",
                Name = "Орендовані нематеріальні активи державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "02").Id,
                Number = "021",
                Name = "Активи на відповідальному зберіганні розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "02").Id,
                Number = "022",
                Name = "Активи на відповідальному зберіганні державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "03").Id,
                Number = "031",
                Name = "Укладені договори (угоди, контракти) розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "03").Id,
                Number = "032",
                Name = "Укладені договори (угоди, контракти) державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "04").Id,
                Number = "041",
                Name = "Непередбачені активи розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "04").Id,
                Number = "042",
                Name = "Непередбачені активи державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "04").Id,
                Number = "043",
                Name = "Тимчасово передані активи",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "05").Id,
                Number = "051",
                Name = "Гарантії та забезпечення надані розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "05").Id,
                Number = "052",
                Name = "Гарантії та забезпечення надані державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "05").Id,
                Number = "053",
                Name = "Непередбачені зобов’язання розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "05").Id,
                Number = "054",
                Name = "Непередбачені зобов’язання державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "06").Id,
                Number = "061",
                Name = "Гарантії та забезпечення отримані розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "06").Id,
                Number = "062",
                Name = "Гарантії та забезпечення отримані державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "07").Id,
                Number = "071",
                Name = "Списана дебіторська заборгованість розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "07").Id,
                Number = "072",
                Name = "Списана дебіторська заборгованість державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "07").Id,
                Number = "073",
                Name = "Невідшкодовані нестачі і втрати від псування цінностей розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "07").Id,
                Number = "074",
                Name = "Невідшкодовані нестачі і втрати від псування цінностей державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "08").Id,
                Number = "081",
                Name = "Бланки документів суворої звітності розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "08").Id,
                Number = "082",
                Name = "Бланки документів суворої звітності державних цільових фондів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "09").Id,
                Number = "091",
                Name = "Передані (видані) активи відповідно до законодавства розпорядників бюджетних коштів",
                Description = ""
            });

            _accountRepository.Insert(new Account()
            {
                CategorieId = сategories.First(x => x.Number == "09").Id,
                Number = "092",
                Name = "Передані (видані) активи відповідно до законодавства державних цільових фондів",
                Description = ""
            });
        }

        #endregion
    }
}
