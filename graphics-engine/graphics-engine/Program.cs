using OpenTK;
using OpenTK.Graphics;

namespace glob {
    public class Game : GameWindow {
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }

        public static void Main() {
        Game game = new Game(800, 600, "LearnOpenTK");
        game.Run(60.0);
        }

    }
}   