﻿using System;
using System.Diagnostics;

namespace Fiddle.Compilers.Implementation.VB {
    public class VbExecuteResult : IExecuteResult {
        public VbExecuteResult(long time, string stdout, object returnVal, ICompileResult cResult,
            Exception exception) {
            Time = time;
            ConsoleOutput = stdout;
            ReturnValue = returnVal;
            CompileResult = cResult;
            Exception = exception;
            Success = exception == null;
        }

        public long Time { get; }
        public bool Success { get; }
        public string ConsoleOutput { get; }
        public object ReturnValue { get; }
        public ICompileResult CompileResult { get; }
        public Exception Exception { get; }
        public int ExceptionLineNr
        {
            get
            {
                if (Exception == null) return -1;
                StackTrace trace = new StackTrace(Exception, true);
                if (trace.FrameCount <= 0) return 0;
                StackFrame frame = trace.GetFrame(0);
                return frame != default(StackFrame) ? frame.GetFileLineNumber() : 0;
            }
        }
    }
}