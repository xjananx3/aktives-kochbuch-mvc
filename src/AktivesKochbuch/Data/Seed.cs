using AktivesKochbuch.Data.Enum;
using AktivesKochbuch.Models;

namespace AktivesKochbuch.Data;

public class Seed
{
    public static void SeedData(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.EnsureCreated();

            if (!context.Rezepte.Any())
            {
                context.Rezepte.AddRange(new List<Rezept>()
                {
                    new Rezept()
                    {
                        RezeptTitel = "Gnocchi Mozarella Tomate Basilikum",
                        Zubereitung = "Tomaten halbieren, Mozarella in scheiben schneiden, Knoclauch hackenKnoblauch in Olivenöl auf hoher Stufe anbraten " +
                                      "nach ca. 40sec, dann Gnocchi zu geben, und das Tomatenmark in Klecksen über die Gnocchis verteilen. Anschließend mit " +
                                      "die Gewürze hinzugeben und durchmischen und mit Tomatenmark ordentlich anbraten. Mit Schluckweise Wasserzugeben eine Sauce " +
                                      "binden. Cherry-Tomaten hinzugeben und unterheben, nach 1-2 Minuten Basilikum und Mozarella und 30g Parmesan hinzugeben, danach " +
                                      "noch Sahne zugeben und etwas aufkochen lassen. Danach Deckel drauf und mittlere Temperatur einstellen, noch 3-5 Minuten köcheln " +
                                      "lassen",
                        RezeptKategorie = RezeptKategorie.Hauptmahlzeit
                    },
                    new Rezept()
                    {
                        RezeptTitel = "Burrata-Brote",
                        Zubereitung = "Brote in Scheiben schneiden und mit Öl oder Butter bestreichen. Tomaten in eine hitzebeständige Form geben und mit ein bisschen " +
                                      "Olivenöl übergießen. Anschließen kommen Brotscheiben und die Tomaten in den Ofen für 7-10 Minuten. Nachdem sie aus dem Ofen sind " +
                                      "kurz (3 Mnuten) liegen lassen. Frühlingszwiebel in kleine Ringe schneiden. Dann Mozzarella und Pesto draufverteilen, die Tomaten " +
                                      "etwas außeinanderreißen und drauflegen. Als Topping Balsamico und Frühlingszwiebeln verteilen und mit Salz und Pfeffer " +
                                      "würzen.",
                        RezeptKategorie = RezeptKategorie.Vorspeise
                    },
                    new Rezept()
                    {
                        RezeptTitel = "Avocado-Ei-Boote",
                        Zubereitung = "- Den Ofen auf 2000C vorheizen. Die Avocados halbieren und die Kerne entfernen. Mit einem Löffel etwas von der Avocado aushöhlen, " +
                                      "um Platz für das Ei zu schaffen. Die Avocadohälften auf ein Backblech legen und vorsichtig je ein Ei in jede Avocadohälfte gießen." +
                                      "Mit Salz und Pfeffer würzen und für etwa 15-20 Minuten backen, bis das Eiweiß gestockt ist.",
                        RezeptKategorie = RezeptKategorie.Snack
                    },
                    new Rezept()
                    {
                        RezeptTitel = "Spinat-Feta-Omelett",
                        Zubereitung = "Die Eier in einer Schüssel verquirlen und mit Salz und Pfeffer würzen. Das Olivenöl in einer Pfanne erhitzen und den Spinat " +
                                      "darin kurz anbraten, bis er zusammenfällt. Die Eier über den Spinat gießen und den zerbröckelten Feta darüber streuen. Das " +
                                      "Omelett bei mittlerer Hitze stocken lassen und anschließend vorsichtig zusammenklappen.",
                        RezeptKategorie = RezeptKategorie.Frühstück
                    }
                });
                context.SaveChanges();
            }
        }
    }

    public static void UpdateRezeptBilder(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            
            var rezepte = context.Rezepte.Where(r => r.Bild == null).ToList();

            foreach (var rezept in rezepte)
            {
                if (rezept.RezeptTitel.Contains("Gnocchi Mozarella Tomate Basilikum"))
                    rezept.Bild = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.pinimg.com%2Foriginals%2F22%2F1f%2F8f%2F221f8faed04cbf925ce1d097943b68fa.jpg&f=1&nofb=1&ipt=876a17ba16d22614d7c75dc4938d24c5ff16ec59e37627b3b1039902b37296d2&ipo=images";

                if (rezept.RezeptTitel.Contains("Burrata-Brote"))
                    rezept.Bild = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.ytimg.com%2Fvi%2FqHO0tBLDwEo%2Fmaxresdefault.jpg&f=1&nofb=1&ipt=0c153bbed84f503ef619ab35fdeb0908e879f8ab6b866863f4be9d00b14bade9&ipo=images";

                if (rezept.RezeptTitel.Contains("Avocado-Ei-Boote"))
                    rezept.Bild = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fthumbs.dreamstime.com%2Fb%2Favocado-ei-boote-mit-speck-72856202.jpg&f=1&nofb=1&ipt=5af09e89cc1393b333eb0ac09c4eae2ab39b893b2c2917085b83613d5f613c11&ipo=images";

                if (rezept.RezeptTitel.Contains("Spinat-Feta-Omelett"))
                    rezept.Bild = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.gutekueche.ch%2Fupload%2Frezept%2F15871%2Fspinat-omelette-mit-feta.jpg&f=1&nofb=1&ipt=c63346bec9851494fbfb7ce9f19909f154d439eb6fca91f98cdaebefe81223d8&ipo=images";
            }
        }
    }
}