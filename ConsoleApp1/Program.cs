
using System;
using System.Runtime.Intrinsics.Arm;
using System.Text;

Start();


void Menu()
{
    Console.WriteLine("-------------------------------------------------------------------");
    Console.WriteLine("Veuillez choisir le jeu à jouer: \t");
    Console.WriteLine("1- Roche/papier/ciseau  2- La devinette  3- Quitter");
    Console.WriteLine("-------------------------------------------------------------------");
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
    Console.WriteLine("-------------------------------------------------------------------");
    Console.WriteLine("Bienvenue dans le jeux roche/papier/ciseau...");
    Console.WriteLine("-------------------------------------------------------------------");
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
        Console.WriteLine("Partie nulle! nous avons choisis le même élément!");
        Autrepartie();
    }
    else if (Gagner(Myelement, UserElement))
    {
        Console.WriteLine($"Votre choix est {UserElement} et mon choix est {Myelement}. Je gagne la partie!");
        Autrepartie();
    }
    else
    {
        Console.WriteLine($"Votre choix est {UserElement} et mon choix est {Myelement}. Vous gagnez la partie!");
        Autrepartie();
    }
}

bool Gagner(string Myelement, string UserElement)
{
    List<List<string>> Gagnant = new List<List<string>>
    {
        new List<string> { "ciseau", "papier"},
        new List<string> { "roche", "ciseau" },
        new List<string> { "papier", "roche" },
    };
    foreach (var couple in Gagnant)
    {
        if (couple[0] == Myelement && couple[1] == UserElement)
        {
            return true;
        }
    }
    return false;
}
void Autrepartie()
{
    Console.WriteLine("Voulez-vous refaire une partie (O/N)?");
    Console.Write("");
    string reponse = Console.ReadLine()!;
    do
    {
        switch (reponse)
        {
            case "O":
                RochePapierCiseau();
                break;
            case "o":
                RochePapierCiseau();
                break;
            case "N":
                Start();
                break;
            case "n":
                Start();
                break;
            default:
                {
                    Autrepartie();
                }
                break;
        }
    } while (reponse is not "N" && reponse is not "n");
}
void Devinette()
{
    Console.WriteLine("-------------------------------------------------------------------");
    Console.WriteLine("Bienvenue dans le devinette");
    Console.WriteLine("-------------------------------------------------------------------");
    Comparaison(ChoisirUnMot());
}

string ChoisirUnMot()
{
    Random rndm = new Random();
    string[] mot = { "banane", "poire", "pomme" , "cerise" , "mangue" , "figue" , "tanguerine" , "fraise" , "framboise" , "bleuet" };
    int randomemot = rndm.Next(mot.Length);
    return mot[randomemot];
}

string  SelectLettre( string mot)
{
    Random rndo = new Random();
    char[] motArray = mot.ToCharArray();
    int randomemotArray1 = rndo.Next(mot.Length);
    int randomemotArray2 = 0;
    int randomemotArray3 = 0;
    do
    {
        randomemotArray2 = rndo.Next(mot.Length);
    } while (randomemotArray1.Equals(randomemotArray2));
    do
    {
        randomemotArray3 = rndo.Next(mot.Length);
    } while (randomemotArray1.Equals(randomemotArray3) && randomemotArray2.Equals(randomemotArray3));
    motArray[randomemotArray1] = '_';
    motArray[randomemotArray2] = '_';
    motArray[randomemotArray3] = '_';
    mot = new string(motArray);
    return mot;
}
void Comparaison(string mot)
{
    string motCache = SelectLettre(mot);
    string motJoueur = "";
    bool MotTrouve = false;
    for (int i = 0; i < 3 && !MotTrouve; i++)
    {
        Console.WriteLine($"LE FRUIT A TROUVER: {motCache}");
        Console.Write("");
        motJoueur = Console.ReadLine()!;
        MotTrouve = mot.Equals(motJoueur);
        if (i == 2)
        {
            Console.WriteLine($"Le mot était : {mot}");
        }
        if (MotTrouve)
        {
            Console.WriteLine("Bravo! Vous avez trouvé le mot!");
        }
    }
}




