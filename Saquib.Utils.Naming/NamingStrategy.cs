using System.Text;

namespace Saquib.Utils.Naming {
    public abstract class NamingStrategy {
        public abstract string Apply( string name );
        protected string Capitalize( string str ) {
            return char.ToUpper( str[0] ) + str.Substring( 1 );
        }
        protected string[] SplitNames( string str, bool preserveCase = false ) {
            return NameSplitter.Split( str, preserveCase );
        }
    }
}
