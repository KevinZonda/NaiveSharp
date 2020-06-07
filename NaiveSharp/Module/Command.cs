﻿using System;
using System.Diagnostics;
using System.IO;
using NaiveSharp.ConstText;

namespace NaiveSharp.Module
{
    public class Command
    {
        // proto only accept http & socks
        public static void RunNaive(string proto)
        {
            var p = new Process();
            p.StartInfo.FileName = PATH.NAIVE_EXE;

            p.StartInfo.Arguments = "--proxy=" +
                                    NaiveCmdBuilder.Proxy(Config.Scheme, Config.Username, Config.Password,
                                        Config.Host) +
                                    " --listen=" + proto.ToLower() + "://127.0.0.1:1080";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
        }

        public static void RunClash()
        {
            var p = new Process();
            p.StartInfo.FileName = PATH.CLASH_EXE;
            p.StartInfo.Arguments = $"-d {PATH.CLASH}";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
        }

        public static void RunPrivoxy()
        {
            var p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = $"/c START /MIN {PATH.PRIVOXY_EXE} {PATH.PRIVOXY_CONF_GFW_TXT}";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
        }


        public static void InitializeTmp()
        {
            try
            {
                Directory.Delete(PATH.TMP, true);
            }
            finally
            {
                Directory.CreateDirectory(PATH.TMP);
            }
        }
    }
}