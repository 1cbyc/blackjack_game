# with open('src/game_logic.py', 'w') as f:
#     f.write("""
import random
from src.utils import calculate_score, display_hand

suits = ['Hearts', 'Diamonds', 'Clubs', 'Spades']
values = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'Jack', 'Queen', 'King', 'Ace']

def create_deck():
    return [{'value': value, 'suit': suit} for value in values for suit in suits]

def play_blackjack():
    print("Welcome to Blackjack!")
    deck = create_deck()
    random.shuffle(deck)

    player_hand = [deck.pop(), deck.pop()]
    dealer_hand = [deck.pop(), deck.pop()]

    while True:
        print("\nYour hand:")
        display_hand(player_hand)
        print(f"Your score: {calculate_score(player_hand)}")

        print("\nDealer's hand:")
        display_hand(dealer_hand, hide_first_card=True)

        player_score = calculate_score(player_hand)
        if player_score == 21:
            print("Blackjack! You win!")
            return
        elif player_score > 21:
            print("Bust! You lose.")
            return

        action = input("Do you want to (h)it or (s)tand? ").lower()
        if action == 'h':
            player_hand.append(deck.pop())
        elif action == 's':
            break
        else:
            print("Invalid input. Please choose 'h' or 's'.")

    print("\nDealer's turn:")
    display_hand(dealer_hand)
    while calculate_score(dealer_hand) < 17:
        print("Dealer hits.")
        dealer_hand.append(deck.pop())
        display_hand(dealer_hand)

    dealer_score = calculate_score(dealer_hand)
    print(f"Dealer's final score: {dealer_score}")

    if dealer_score > 21 or player_score > dealer_score:
        print("You win!")
    elif player_score == dealer_score:
        print("It's a tie!")
    else:
        print("Dealer wins.")
""")
