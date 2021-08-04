using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFire.Books
{
    /// <summary>
    /// Executa a criação de novo documento
    /// </summary>
    public class WriterExecute 
    {
        public TrapError TrappedError = new TrapError();
        public void Go(string xsltsource, string basecopy, string outfile, bool mergefile, ThunderFire.Books.BOOKS WhatBook)
        {
            ThunderFire.Books.Writer EBook = new ThunderFire.Books.Writer();
            string basepath = ThunderFire.Books.ResourceBase.BasePath();
            EBook.XsltSource = MazeFire.Directories.CombinePath(basepath, xsltsource);
            EBook.DictionaryBaseCopy = MazeFire.Directories.CombinePath(basepath, basecopy);
            EBook.TargetFile = ThunderFire.Books.ResourceBase.OutputPath(outfile);
            bool goMerge = true;

            try
            {
                if (mergefile)
                {
                    if (!MergeFile(EBook.DictionaryBaseCopy))
                        goMerge = false;
                }

                if (goMerge)
                {
                    if (EBook.Create(WhatBook))
                    {
                        TrappedError.SetError("OK");
                        TrappedError.UserError = String.Format("Arquivo {0} gerado com sucesso", Path.GetFileNameWithoutExtension(outfile).ToUpper()) + Environment.NewLine;
                    }
                    else
                        TrappedError = EBook.TrappedError;
                }
            }
            catch (Exception Error)
            {
                TrappedError.ErrorCode = MazeFire.ErrorManager.GetErrorCode(Error);
                if (TrappedError.ErrorCode != "")
                    TrappedError.SetError(TrappedError.ErrorCode);
                TrappedError.ErrorMessage = Error.Message;
                TrappedError.ErrorObject = Error;
            }
            finally
            {
                EBook = null;
            }
        }


        private bool MergeFile(string targetfile)
        {
            string basepath = ThunderFire.Books.ResourceBase.OutputPath();
            string sourcefile = MazeFire.Directories.CombinePath(basepath, "ingles.xml");
            Merge p = new Merge();
            bool RETURN_VALUE = true;
            try
            {
                p.Do(sourcefile, targetfile);
                if (p.TrappedError.HasError())
                {
                    TrappedError = p.TrappedError;
                    RETURN_VALUE = false;
                }
                else
                {
                    TrappedError.SetError("OK");
                    TrappedError.CurrentMethod = MethodBase.GetCurrentMethod().Name;
                    TrappedError.UserError = String.Format("Arquivo {0} merged", sourcefile);
                }
                p = null;
            }
            catch (Exception Error)
            {
                TrappedError.ErrorCode = MazeFire.ErrorManager.GetErrorCode(Error);
                if (TrappedError.ErrorCode != "")
                    TrappedError.SetError(TrappedError.ErrorCode);
                TrappedError.ErrorMessage = Error.Message;
                TrappedError.ErrorObject = Error;
                RETURN_VALUE = false;
            }
            finally
            {
                p = null;
            }
            return RETURN_VALUE;
        }
    }
}