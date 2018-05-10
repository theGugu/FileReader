// Copyright(c) 2018 Lorenzo Gugliara
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
// of the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions: The above copyright notice and this permission
// notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

// Todo:
// - Add multicomment support (List<string> & Linq?)
// - Add multiline support (List<string> & Linq?)

using System.IO;

namespace Extensions.System.IO
{
    public class StreamExtension : StreamReader
    {
        public string CommentString { get { return commentString; } }
        private string commentString { get; set; } = "//";

        public StreamExtension(string path) : this(path, null)
        {

        }
        public StreamExtension(string path, string comment) : base(path)
        {
            SetCommentString(comment);
        }

        public virtual void SetCommentString(string comment)
        {
            if (comment != null)
            {
                comment = comment.Trim();
                if (comment != string.Empty)
                {
                    commentString = comment;
                }
            }
        }

        public void NextLine(ref string line)
        {
            while ((line = ReadLine()) != null)
            {
                if (line.TrimStart().Substring(0, ((line.TrimStart().Length > commentString.Length) ? commentString.Length : line.TrimStart().Length)) != commentString) break;
            }
        }
        public string NextLine()
        {
            string res;
            while ((res = ReadLine()) != null) if (res.TrimStart().Substring(0, ((res.TrimStart().Length > commentString.Length) ? commentString.Length : res.TrimStart().Length)) != commentString) break;
            return res;
        }
    }
}
