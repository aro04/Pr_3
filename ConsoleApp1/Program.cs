
Start();


void Menu()
{
    Console.WriteLine("Veuillez choisir le jeu à jouer: \t");
    Console.WriteLine("1- Roche/papier/ciseau  2- La dvinette  3- Quiter");
    Console.Write("\t\n ");
}

void Start()
{
    string choice;
    do
    {
        Menu();
        choice = Console.ReadLine()!;
        switch (choice)
        {
            case "1":
                RochePapierCiseau();
                break;
            case "2":
                Devinette();
                break;
            case "3":
                Environment.Exit(3);
                break;
            default:
                {
                    afficherMessageErreur();
                }
                break;
        }
    } while (choice is not "3");
}

void afficherMessageErreur()
{
    Console.WriteLine("Veuillez effectuer un choix valide...");
}

void RochePapierCiseau()
{
    Console.WriteLine("Bienvenu dans le jeux roche/papier/ciseau...");
    string UserElement = ChoixDesElements();
    string Myelement = SelectElement();
    Compare(Myelement, UserElement);
}

string SelectElement()
{
    Random rnd = new Random();
    string[] elements = { "roche", "papier", "ciseau" };
    int randomelements = rnd.Next(elements.Length);
    return elements[randomelements];
}

string ChoixDesElements()
{
    string[] elements = { "roche", "papier", "ciseau" };
    Console.WriteLine("J'ai déjà choisis mon élément! A votre tour de choisir l'élément: ");
    Console.Write(" ");
    string UserElement = Console.ReadLine()!;
    bool choixvalide = false;
    foreach (string mot in elements)
    {
        if (UserElement.Equals(mot))
        {
            choixvalide = true;
            break;
        }
    }
    if (!choixvalide)
    {
        Console.WriteLine("Votre choix est  invalide, veuillez saisir à nouveau: ");
        return ChoixDesElements();
    }
    return UserElement;
}


void Compare(string Myelement, string UserElement)
{
    if (Myelement.Equals(UserElement))
    {
        Console.WriteLine($"Votre Choix est {UserElement} et mon choix est {Myelement}. La partie est nulle.");
    }
    else if (Gagner(Myelement, UserElement))
    {
        Console.WriteLine($"Votre Choix est {UserElement} et mon choix est {Myelement}. Je gagne la partie!");
    }
    else
    {
        Console.WriteLine($"Votre Choix est {UserElement} et mon choix est {Myelement}. Vous gagnez la partie!");
    }
}

bool Gagner(string Myelement, string UserElement)
{
    List<List<string>> Gagnant = new List<List<string>>
    {
        new List<string> { "ciseau", "papier"},
        new List<string> { "papier", "roche" },
        new List<string> { "roche", "ciseau" },
    };
    foreach (var couple in Gagnant)
    {
        if (couple.Contains(Myelement) && couple.Contains(UserElement))
        {
            return true;
        }
    }
    return false;
}

//bool Perdre(string Myelement, string UserElement)
//{
// List<List<string>> Perdant = new List<List<string>>
//{
// new List<string> { "papier", "ciseau"},
//new List<string> { "ciseau", "roche" },
//new List<string> { "roche", "papier" },
//};
//foreach (var couple in Perdant)
//{
//  if (couple.Contains(Myelement) && couple.Contains(UserElement))
//{
//  return true;
//}
//}
//return false;
//}
void Devinette()
{

}