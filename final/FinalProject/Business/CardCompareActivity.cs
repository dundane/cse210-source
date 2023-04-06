using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business {
  public class CardCompareActivity : Activity {
    public CardCompareActivity(Deck deckForActivity) : base(deckForActivity) { }

    public override string ActivityDescription() {
      StringBuilder instructions = new StringBuilder();
      instructions.AppendLine("This activity will return your commander and 2 random cards from your deck so you can look at what they do together.");
      return instructions.ToString();
    }
    public override string RunActivity() {
      StringBuilder cardDetails = new StringBuilder();
      List<Card> cardsToDisplay = new List<Card>();
      int cardOneIndex = -1;
      int cardTwoIndex =-1;
      Random randomIndex = new Random(DateTime.Now.Millisecond);
      while (cardOneIndex == cardTwoIndex) { 
        cardOneIndex = randomIndex.Next(activityDeck.Cards.Count);
        cardTwoIndex = randomIndex.Next(activityDeck.Cards.Count);
      }
      cardsToDisplay.Add(activityDeck.Commander);
      cardsToDisplay.Add(activityDeck.Cards[cardOneIndex]);
      cardsToDisplay.Add(activityDeck.Cards[cardTwoIndex]);

      foreach (Card card in cardsToDisplay) {
        cardDetails.AppendLine("");
        cardDetails.AppendLine($"{card.Name} {card.ManaCost}");
        cardDetails.AppendLine(card.OracleText);
      }
      return cardDetails.ToString();
    }
  }
}
