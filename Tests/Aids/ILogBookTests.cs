using System;

namespace North.Tests.Aids {

    public interface ILogBookTests {
        void WriteEntry(string message);

        void WriteEntry(Exception e);
    }

}


