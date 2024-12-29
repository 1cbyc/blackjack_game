with open('main.py', 'w') as f:
    f.write("""
from src.game_logic import play_blackjack

if __name__ == "__main__":
    play_blackjack()
""")
