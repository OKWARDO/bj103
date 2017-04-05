using System;
using System.Collections.Generic;
using System.Text;
using Hidden;
class Program : Shell
{
    static void Main()
    {
        // Write your code starting here...
        Random rand = new Random();
        int[] Index = new int[52];
        int[] Value = new int[52];
        char[] Suit = new char[52];
        string[] Face = new string[52];

        int[] pIndex = new int[7];  // Player arrays for his cards...
        int[] pValue = new int[7];
        char[] pSuit = new char[7];
        string[] pFace = new string[7];
        int numP = 0; // numP stores how many cards in the Player's hand

        int numDeck = 0;
        numDeck = DefineDeck(Index, Value, Suit, Face, numDeck);

        Shuffle(rand, Index, Value, Suit, Face);   //Shuffle the deck

        numDeck = 0; // Initially, point to the first card at top of the deck

        DealPlayerHand(Index, Value, Suit, Face, pIndex, pValue, pSuit, pFace, ref numP, ref numDeck);

        ShowPlayerHand(pSuit, pFace, numP);  
//        

        Pause();

    }

    private static void DealPlayerHand(int[] Index, int[] Value, char[] Suit, string[] Face, int[] pIndex, int[] pValue, char[] pSuit, string[] pFace, ref int numP, ref int numDeck)
    {
        // Deal out 1st 2 cards to the player...
        pIndex[numP] = Index[numDeck];
        pValue[numP] = Value[numDeck];
        pSuit[numP] = Suit[numDeck];
        pFace[numP] = Face[numDeck];
        numDeck = numDeck + 1;
        numP = numP + 1;

        pIndex[numP] = Index[numDeck];
        pValue[numP] = Value[numDeck];
        pSuit[numP] = Suit[numDeck];
        pFace[numP] = Face[numDeck];
        numDeck = numDeck + 1;
        numP = numP + 1;
    }

    private static void ShowPlayerHand(char[] pSuit, string[] pFace, int numP)
    {
        Console.Write("Player: ");
        for (int i = 0; i < numP; i = i + 1)
        {
            Console.Write(pFace[i] + pSuit[i] + " ");
        }
        Console.WriteLine();
    }

    private static void DisplayDeck(char[] Suit, string[] Face)
    {
        for (int i = 0; i <= 51; i = i + 1)
        {
            Output(Face[i] + Suit[i]);
        }
    }

    private static int DefineDeck(int[] Index, int[] Value, char[] Suit, string[] Face, int numDeck)
    {
        for (int sidx = 3; sidx <= 6; sidx = sidx + 1)
        {
            for (int cidx = 1; cidx <= 13; cidx = cidx + 1)
            {

                Index[numDeck] = cidx;
                Suit[numDeck] = (char)sidx;

                if (Index[numDeck] == 1)
                {
                    Value[numDeck] = 11;
                    Face[numDeck] = "A";
                }

                else if (Index[numDeck] >= 2 && Index[numDeck] < 11)
                {// Number cards from 2-10
                    Value[numDeck] = cidx;
                    Face[numDeck] = cidx.ToString();
                }
                else if (Index[numDeck] == 11)
                { // Jack
                    Value[numDeck] = 10;
                    Face[numDeck] = "J";
                }
                else if (Index[numDeck] == 12)
                {//Queen
                    Value[numDeck] = 10;
                    Face[numDeck] = "Q";
                }


                else if (Index[numDeck] == 13)
                {//King
                    Value[numDeck] = 10;
                    Face[numDeck] = "K";
                }
                numDeck = numDeck + 1;
            }
        }
        return numDeck;
    }

    private static void Shuffle(Random rand, int[] Index, int[] Value, char[] Suit, string[] Face)
    {
        for (int i = 0; i < 104; i = i + 1)
        {
            int r = rand.Next(0, 52);//draw random card out of deck
            int tIndex, tValue;
            char tSuit;
            string tFace;
            tIndex = Index[r];//step one of swap
            tValue = Value[r];
            tSuit = Suit[r];
            tFace = Face[r];
            Index[r] = Index[0];//step two of swap
            Value[r] = Value[0];
            Suit[r] = Suit[0];
            Face[r] = Face[0];
            Index[0] = tIndex;//step three of swap
            Value[0] = tValue;
            Suit[0] = tSuit;
            Face[0] = tFace;
        }
    }
  }
