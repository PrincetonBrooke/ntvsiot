﻿//*********************************************************//
//    Copyright (c) Microsoft. All rights reserved.
//    
//    Apache 2.0 License
//    
//    You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
//    
//    Unless required by applicable law or agreed to in writing, software 
//    distributed under the License is distributed on an "AS IS" BASIS, 
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or 
//    implied. See the License for the specific language governing 
//    permissions and limitations under the License.
//
//*********************************************************//

using System;
using System.Diagnostics;
using Microsoft.VisualStudio.Text;

namespace TestUtilities.Mocks {
    public class MockTextSnapshotLine : ITextSnapshotLine {
        private readonly MockTextSnapshot _snapshot;
        private readonly string _text;
        private readonly int _lineNo, _startPos;
        private readonly string _lineBreak;

        public MockTextSnapshotLine(MockTextSnapshot snapshot, string text, int lineNo, int startPos, string lineBreak) {
            Debug.Assert(!text.EndsWith("\n"));
            _snapshot = snapshot;
            _text = text;
            _lineNo = lineNo;
            _startPos = startPos;
            _lineBreak = lineBreak;
        }

        public SnapshotPoint End {
            get { return new SnapshotPoint(_snapshot, _startPos + _text.Length); }
        }

        public SnapshotPoint EndIncludingLineBreak {
            get {
                return new SnapshotPoint(_snapshot, _startPos + _text.Length + _lineBreak.Length);
            }
        }

        public SnapshotSpan Extent {
            get { return new SnapshotSpan(Start, End); }
        }

        public SnapshotSpan ExtentIncludingLineBreak {
            get {
                return new SnapshotSpan(Start, EndIncludingLineBreak);
            }
        }

        public string GetLineBreakText() {
            return _lineBreak;
        }

        public string GetText() {
            return _text;
        }

        public string GetTextIncludingLineBreak() {
            return _text + GetLineBreakText();
        }

        public int Length {
            get { return _text.Length; }
        }

        public int LengthIncludingLineBreak {
            get { return _text.Length + LineBreakLength; }
        }

        public int LineBreakLength {
            get {
                return _lineBreak.Length;
            }
        }

        public int LineNumber {
            get { return _lineNo; }
        }

        public ITextSnapshot Snapshot {
            get { return _snapshot; }
        }

        public SnapshotPoint Start {
            get { return new SnapshotPoint(_snapshot, _startPos); }
        }
    }
}
