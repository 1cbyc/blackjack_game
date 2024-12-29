# # with open('src/utils.py', 'w') as f:
# #     f.write("""
# def calculate_score(hand):
#     score = 0
#     aces = 0
#     for card in hand:
#         if card['value'] in ['Jack', 'Queen', 'King']:
#             score += 10
#         elif card['value'] == 'Ace':
#             aces += 1
#             score += 11
#         else:
#             score += int(card['value'])

#     while score > 21 and aces:
#         score -= 10
#         aces -= 1

#     return score

# def display_hand(hand, hide_first_card=False):
#     if hide_first_card:
#         print("[Hidden Card],", *[f"{card['value']} of {card['suit']}" for card in hand[1:]])
#     else:
#         print(*[f"{card['value']} of {card['suit']}" for card in hand])
# """)
def calculate_score(hand):
    score = 0
    aces = 0
    for card in hand:
        if card['value'] in ['Jack', 'Queen', 'King']:
            score += 10
        elif card['value'] == 'Ace':
            aces += 1
            score += 11
        else:
            score += int(card['value'])

    while score > 21 and aces:
        score -= 10
        aces -= 1

    return score

def display_hand(hand, hide_first_card=False):
    if hide_first_card:
        print("[Hidden Card],", *[f"{card['value']} of {card['suit']}" for card in hand[1:]])
    else:
        print(*[f"{card['value']} of {card['suit']}" for card in hand])