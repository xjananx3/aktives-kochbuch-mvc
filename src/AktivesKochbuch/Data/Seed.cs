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
}