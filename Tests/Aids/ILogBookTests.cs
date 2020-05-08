using System;

namespace North.Aids {

    public interface ILogBookTests {
        void WriteEntry(string message);

        void WriteEntry(Exception e);
    }

}


