using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
//using LiteMiner.classes;


namespace IR_HW
{
    class Triple
    {
        public Triple()
        {
            
        }

        #region variables

        public int indexnow;
        public List<string> subjjj;
        public List<string> obj;
        public List<string> objjj;
        public StringBuilder pred;       
        public string subject;


        #endregion variables

        #region SVO

        int Get_object(string[] Tokens1, string[] Tags1, int index)
        {
            obj = new List<string>();
            subjjj = new List<string>();
            int adv = 0;
            for (int i = index; i < Tags1.Length; i++)
            {
                if (!Tags1[i].Contains("JJ"))


                    if (Tokens1[i].Equals("that"))
                    {
                        adv = 1;
                        break;
                    }
                    else if (Tags1[i].Contains("TO"))
                    {
                        adv = 2;
                        break;
                    }
                    else if ((i < (Tokens1.Length - 1)) && Tokens1[i].Equals("for") && (Tags1[i + 1].Contains("PRP") || Tags1[i + 1].Contains("NN")))
                    {
                        adv = 3;
                        break;
                    }
                    else if (Tags1[i].Contains("WP"))
                    {
                        adv = 4;
                        break;
                    }
                    else if (Tags1[i].Contains("NN") || Tags1[i].Contains("PRP"))
                    {
                        adv = 5;
                        break;
                    }
                    else if (Tokens1[i].Equals("it") && i + 1 < Tokens1.Length && Tokens1[i].Equals("that"))
                    {
                        adv = 6;
                        break;
                    }
            }
            if (adv == 1)
            {

                string s = "";
                for (int i = index; i < Tokens1.Length; i++)
                {
                    if (Tokens1[i].Equals("that") && i + 1 < Tokens1.Length)
                    {
                        if (Tags1[i + 1].Contains("PRP") && i + 2 < Tokens1.Length)
                        {
                            if (Tags1.Contains("VB"))
                            {
                                for (int j = index; j < Tokens1.Length; j++)
                                {
                                    if (!Tags1.Contains("JJ") && !Tags1.Contains("."))
                                    {
                                        if (j == index)
                                            s = Tokens1[j];
                                        else
                                            s += " " + Tokens1[j];


                                    }
                                    else if (Tags1.Contains("JJ"))
                                        objjj.Add(Tokens1[j]);
                                }
                                obj.Add(s);
                                return 1;
                            }
                        }
                    }
                }
                return 0;
            }


            else if (adv == 2)
            {
                string objg = "";
                bool ok = true;
                for (int i = 0; i < Tokens1.Length; i++)
                {


                    if (Tags1[i].Contains("JJ"))
                        objjj.Add(Tokens1[i]);
                    else if (Tags1[i].Contains("TO") && ok)
                    {
                        ok = false;
                        objg = Tokens1[i];
                        for (int g = i + 1; g < Tags1.Length; g++)
                            if (Tags1[g].Contains("VB"))
                            {
                                objg += " ";
                                objg += Tokens1[g];


                            }
                    }




                }

                obj.Add(objg);
                return 1;
            }

            else if (adv == 3)
            {
                string ss = "";
                int k = 0;
                bool ok = false;
                for (int i = index; i < Tokens1.Length; i++)
                {
                    if (Tags1[i].Contains("JJ"))
                    {
                        objjj.Add(Tokens1[i]);
                    }
                    else if (Tokens1[i].Equals("for") && i + 1 < Tokens1.Length)
                    {
                        k = i + 1;
                        ss += Tokens1[i] + " " + Tokens1[k];
                        if (i + 2 < Tokens1.Length && Tags1[i + 2].Contains("TO"))
                        {
                            k = i + 2;
                            ss += " " + Tokens1[k];
                            if (i + 3 < Tokens1.Length && Tags1[i + 3].Contains("VB"))
                            {
                                k = i + 3;
                                ss += " " + Tokens1[k];
                                // break;
                            }

                        }
                        else if (Tags1[k].Contains("PRP"))
                        {
                            for (int o = k + 1; o < Tags1.Length; o++)
                            {
                                if (Tags1[o].Contains("NN"))
                                    ss += " " + Tokens1[o];
                            }
                        }
                    }

                }

                obj.Add(ss);
                return 1;
            }

            else if (adv == 4)
            {
                string s = "";
                bool ok = false;
                for (int i = index; i < Tokens1.Length; i++)
                {
                    if (Tags1[i].Contains("JJ"))
                    {
                        objjj.Add(Tokens1[i]);
                    }
                    else if (Tags1[i].Contains("WP"))
                    {
                        s += Tokens1[i];
                        ok = true;
                    }
                    else if (ok)
                    {
                        if (!Tokens1[i].Equals(".") && !Tokens1[i].Equals(","))
                            s += " " + Tokens1[i];
                    }
                }

                obj.Add(s);
                return 1;
            }
            else if (adv == 5)
            {
                bool ok = true;
                string s = "";
                for (int i = index; i < Tokens1.Length; i++)
                {
                    if (Tags1[i].Contains("JJ"))
                    {
                        objjj.Add(Tokens1[i]);
                    }
                    else if (Tags1[i].Contains("NN") && ok)
                    {
                        ok = false;
                        s = Tokens1[i];
                        // break;
                    }
                    else
                        if (Tags1[i].Contains("PRP") && s.Length == 0)
                        {
                            s = Tokens1[i];
                            if (Tags1[i].Contains("$") && i < (Tokens1.Length - 1))
                            {
                                s += Tokens1[i + 1];
                            }
                        }
                }

                obj.Add(s);
                return 1;
            }
            else if (adv == 6)
            {
                bool ok = true;
                string s = "";
                for (int i = index; i < Tokens1.Length; i++)
                {
                    if (Tags1[i].Contains("JJ"))
                    {
                        objjj.Add(Tags1[i]);
                    }
                    else if (Tokens1[i].Equals("it") && Tokens1[i + 1].Equals("that") && ok)
                    {
                        s = Tokens1[i];
                        ok = false;
                    }
                }

                obj.Add(s);
                return 1;
            }


            return 0;

        }


        string get_pred(string[] tokens, string[] tags)
        {
            indexnow = 0;
            int i = 0;
            for (i = 0; i < tokens.Length; i++)
                if (tags[i].Contains("VB") || tags[i].Contains("MD"))
                    break;

            if (i < tokens.Length)
            {
                if ((i < (tokens.Length - 1)) && tags[i + 1].Contains("VB"))
                {
                    if (tokens[i].Equals("am") || tokens[i].Equals("is") || tokens[i].Equals("are") || tokens[i].Equals("was") || tokens[i].Equals("were"))
                    {
                        if (tags[i + 1].Contains("VBG"))
                        {
                            if ((i < (tokens.Length - 3)) && tokens[i + 1].Equals("going") && tokens[i + 2].Equals("to") && tags[i + 3].Contains("VB"))
                            {
                                indexnow = i + 4;

                                return tokens[i + 3];  
                            }
                            else if (tags[i + 1].Contains("VBG"))
                            {
                                indexnow = i + 2;
                                return tokens[i + 1];
                            }
                        }
                        else
                        {
                            indexnow = i + 1;
                            return tokens[i];
                        }
                    }
                    else if (tokens[i].Equals("has") || tokens[i].Equals("have") || tokens[i].Equals("had"))
                    {
                        if ((i < (tokens.Length - 1)) && tokens[i + 1].Equals("been") && tags[i + 2].Contains("VB"))/////////////////////////****
                        {
                            indexnow = i + 3;
                            return tokens[i + 2];
                        }
                        else if ((i < (tokens.Length - 1)) && tags[i + 1].Contains("VB"))
                        {
                            indexnow = i + 2;
                            return tokens[i + 1];
                        }
                        else
                        {
                            indexnow = i + 1;
                            return tokens[i];
                        }
                    }
                    else if ((i < (tokens.Length - 1)) && (tokens[i].Equals("will") || tokens[i].Equals("wo")) && tags[i + 1].Contains("VB"))
                    {
                        indexnow = i + 2;
                        return tokens[i + 1];
                    }
                    else
                    {
                        indexnow = i + 1;
                        return tokens[i];
                    }
                }
                else if (i < tokens.Length)
                {
                    indexnow = i + 1;
                    return tokens[i];
                }
            }

            return "";

        }


        string Get_sub(string[] tokens, string[] Tags, StringBuilder Pred)
        {
            string sub = "";       
            List<int> Act = new List<int>();

            //Delete DT and put actual tokens in act...

            for (int i = 0; i < Tags.Length; i++)
                if (!Tags[i].Equals("DT"))
                    Act.Add(i);
            string[] Tokens1 = new string[Act.Count];
            string[] Tags1 = new string[Act.Count];
            int l = 0;
            for (int j = 0; j < tokens.Length; j++)
            {
                if (Act.Contains(j))
                {
                    Tokens1[l] = tokens[j];
                    Tags1[l] = Tags[j];
                    l++;
                }

            }

            int adv = 0;
            for (int i = 0; i < Tags1.Length; i++)
            {
                if (!Tags1[i].Contains("JJ")) //JJ is an adjective like "black"


                    if (Tokens1[i].Equals("That"))
                    {
                        adv = 1;
                        break;
                    }
                    else if (Tags1[i].Contains("TO"))
                    {
                        adv = 2;
                        break;
                    }
                    else if ((i < (Tokens1.Length - 1)) && Tags1[i].Contains("NN") && Tags1[i + 1].Contains("POS"))
                    {
                        adv = 3;
                        break;
                    }
                    else if (Tags1[i].Contains("PRP"))
                    {
                        adv = 4;
                        break;
                    }
                    else if (Tags1[i].Contains("NN")) //Singular Noun
                    {
                        adv = 5;
                        break;
                    }
            }

            if (adv == 5)
            {
                bool ok = true;
                int y = 0;
                for (int i = 0; i < Tokens1.Length; i++)
                {
                    if (Tags1[i].Contains("VB") || Tags1[i].Contains("MD"))
                    {
                        Pred.Clear();
                        indexnow = 0;
                        Pred.Append(get_pred(Tokens1, Tags1));
                        if (indexnow != 0)
                            indexnow = Get_object(Tokens1, Tags1, indexnow);
                        break;
                    }
                    else
                    {
                        if (Tags1[i].Contains("JJ"))
                            subjjj.Add(Tokens1[i]);
                        else if (Tags1[i].Contains("NN") && ok)
                        {
                            sub = Tokens1[i];
                            ok = false;
                        }
                    }

                }
                return sub;
            }

            else if (adv == 4)
            {
                for (int i = 0; i < Tokens1.Length; i++)
                {
                    if (Tags1[i].Contains("VB") || Tags1[i].Contains("MD"))
                    {
                        Pred.Clear();
                        indexnow = 0;
                        Pred.Append(get_pred(Tokens1, Tags1));
                        if (indexnow != 0)
                            indexnow = Get_object(Tokens1, Tags1, indexnow);
                        break;
                    }


                    else
                    {
                        if (Tags1[i].Contains("JJ"))
                            subjjj.Add(Tokens1[i]);
                        else if (Tags1[i].Contains("PRP"))
                            sub = Tokens1[i];
                        else if (Tags1[i].Contains("NN"))
                        {
                            sub += " ";
                            sub += Tokens1[i];
                        }
                    }

                }
                return sub;
            }

            else if (adv == 3)
            {
                bool ok = false;
                for (int i = 0; i < Tokens1.Length; i++)
                {
                    if (Tags1[i].Contains("VB") || Tags1[i].Contains("MD"))
                    {
                        Pred.Clear();
                        indexnow = 0;
                        Pred.Append(get_pred(Tokens1, Tags1));
                        if (indexnow != 0)
                            indexnow = Get_object(Tokens1, Tags1, indexnow);
                        break;
                    }
                    else
                    {
                        if (Tags1[i].Contains("JJ"))
                            subjjj.Add(Tokens1[i]);
                        else if (Tags1[i].Contains("NN") && !ok)
                        { sub = Tokens1[i]; ok = true; }
                        else if (Tags1[i].Contains("POS"))
                        {
                            sub += " ";
                            sub += Tokens1[i];
                        }
                        else if (Tags1[i].Contains("NN"))
                        {
                            sub += " ";
                            sub += Tokens1[i];
                        }
                    }

                }
                return sub;
            }

            else if (adv == 2)
            {
                bool ok = false;
                for (int i = 0; i < Tokens1.Length; i++)
                {
                    if (Tags1[i].Contains("VB") || Tags1[i].Contains("MD"))
                    {
                        Pred.Clear();
                        indexnow = 0;
                        Pred.Append(get_pred(Tokens1, Tags1));
                        if (indexnow != 0)
                            indexnow = Get_object(Tokens1, Tags1, indexnow);
                        break;
                    }
                    else
                    {
                        if (Tags1[i].Contains("JJ"))
                            subjjj.Add(Tokens1[i]);
                        else if (Tags1[i].Contains("TO"))
                        {
                            sub = Tokens1[i];
                            if (Tags1[i + 1].Contains("VB"))
                            {
                                sub += " ";
                                sub += Tokens1[i + 1];
                                ok = true;
                                i++;
                            }
                        }
                        else
                        {
                            ok = true;
                            sub += " ";
                            sub += Tokens1[i];
                        }

                    }

                }
                return sub;
            }


            else if (adv == 1)
            {
                bool ok = false;
                for (int i = 0; i < Tokens1.Length; i++)
                {
                    if (Tags1[i].Contains("VB") || Tags1[i].Contains("MD"))
                    {
                        Pred.Clear();
                        indexnow = 0;
                        Pred.Append(get_pred(Tokens1, Tags1));
                        if (indexnow != 0)
                            indexnow = Get_object(Tokens1, Tags1, indexnow);
                        break;
                    }
                    else
                    {
                        if (Tags1[i].Contains("JJ"))
                            subjjj.Add(Tokens1[i]);
                        else if (Tokens1[i].Equals("That"))
                        {
                            sub = Tokens1[i];
                            if (Tags1[i + 1].Contains("PRP"))
                            {
                                if ((i < (Tokens1.Length - 4)) && Tags1[i + 2].Contains("VB") && Tags1[i + 3].Contains("VB") && Tags1[i + 4].Contains("VB"))
                                {
                                    sub += " ";
                                    sub += Tokens1[i + 1];
                                    sub += " ";
                                    sub += Tokens1[i + 2];
                                    sub += " ";
                                    sub += Tokens1[i + 3];
                                    sub += " ";
                                    sub += Tokens1[i + 3];
                                    ok = true;
                                    i += 4;
                                }
                                else if ((i < (Tokens1.Length - 3)) && Tags1[i + 2].Contains("VB") && Tags1[i + 3].Contains("VB"))
                                {
                                    sub += " ";
                                    sub += Tokens1[i + 1];
                                    sub += " ";
                                    sub += Tokens1[i + 2];
                                    sub += " ";
                                    sub += Tokens1[i + 3];
                                    ok = true;
                                    i += 3;
                                }
                                else if ((i < (Tokens1.Length - 2)) && Tags1[i + 2].Contains("VB"))
                                {
                                    sub += " ";
                                    sub += Tokens1[i + 1];
                                    sub += " ";
                                    sub += Tokens1[i + 2];
                                    ok = true;
                                    i += 2;
                                }
                            }
                        }
                        else
                        {
                            ok = true;
                            sub += " ";
                            sub += Tokens1[i];
                        }

                    }

                }
                return sub;
            }

            Pred.Clear();
            indexnow = 0;
            Pred.Append(get_pred(Tokens1, Tags1));


            return sub;
        }



        #endregion SVO
        //=============================== END extracting Triples (Subj + Pred + Obj) =====================================//




        #region NLP

        private string[] SplitSentences(string paragraph)
        { bool test = true;
             if (File.Exists(@"c:\models\EnglishSD.nbin"))
                  test = false;
            OpenNLP.Tools.SentenceDetect.MaximumEntropySentenceDetector mSentenceDetector;
            {
                    mSentenceDetector = new OpenNLP.Tools.SentenceDetect.EnglishMaximumEntropySentenceDetector(@"c:\models\"+"EnglishSD.bin");
            }
            
            return mSentenceDetector.SentenceDetect(paragraph);
        }


        private string[] TokenizeSentence(string sentence)
        {
            OpenNLP.Tools.Tokenize.EnglishMaximumEntropyTokenizer mTokenizer;
            // if (mTokenizer == null)
            {
                mTokenizer = new OpenNLP.Tools.Tokenize.EnglishMaximumEntropyTokenizer(@"C:\models\" + "EnglishTok.nbin");
            }

            return mTokenizer.Tokenize(sentence);
        }

        private string[] PosTagTokens(string[] tokens)
        {
            OpenNLP.Tools.PosTagger.EnglishMaximumEntropyPosTagger mPosTagger;
            //if (mPosTagger == null)
            {
                mPosTagger = new OpenNLP.Tools.PosTagger.EnglishMaximumEntropyPosTagger(@"C:\models\" + "EnglishPOS.nbin", @"C:\Open Nlp\Models\" + @"\Parser\tagdict");

            }

            return mPosTagger.Tag(tokens);
        }
        #endregion NLP


        #region support
        string[] Shortcuts(string[] tokens, string[] tags)
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i].Contains("'"))
                {
                    if (tokens[i].Equals("'m") && (tokens[i - 1].Equals("i") || tokens[i - 1].Equals("I")))
                    {
                        tokens[i] = "am";
                    }
                    else if (tokens[i].Equals("'s") &&
                        (tokens[i - 1].Equals("he") || tokens[i - 1].Equals("she") || tokens[i - 1].Equals("it") || tokens[i - 1].Equals("He") || tokens[i - 1].Equals("She") || tokens[i - 1].Equals("It")))
                    {
                        if (tags[i + 1].Equals("VBG"))
                            tokens[i] = "is";
                        else
                            if (tags[i + 1].Equals("VBN"))
                                tokens[i] = "has";
                            else
                                tokens[i] = "is";
                    }
                    else if (tokens[i].Equals("'s"))
                    {
                        tokens[i] = "is";
                    }
                    else if (tokens[i].Equals("'re") &&
                       (tokens[i - 1].Equals("we") || tokens[i - 1].Equals("they") || tokens[i - 1].Equals("you") || tokens[i - 1].Equals("We") || tokens[i - 1].Equals("They") || tokens[i - 1].Equals("You")))
                    {
                        tokens[i] = "are";
                    }
                    else if (tokens[i].Equals("'ll"))
                    {
                        tokens[i] = "will";
                    }
                    else if (tokens[i].Equals("'ve"))
                    {
                        tokens[i] = "have";
                    }
                    else if (tokens[i].Equals("'d"))
                    {
                        if (tags[i + 1].Equals("VBN"))
                            tokens[i] = "had";
                        else if (tags[i + 1].Equals("VB"))
                            tokens[i] = "would";//////////////////////////////////////***********************
                        else
                            tokens[i] = "had";

                    }
                    else
                        tokens[i] = "";
                }
            }


            return tokens;
        }

        #endregion support





        #region process

        public void PrintRDF()
        {
            using (StreamWriter output1 = new StreamWriter("RDF.txt", false, Encoding.Default))
            {
                output1.WriteLine("<rdf:RDF xmlns:rdf=\"http://www.w3.org/1999/02/22-rdf-syntax-ns#\"  ");
                output1.WriteLine("xmlns:dis=\"http://dbpedia.com/disdb#\">\n");

                
                    string ss = "<rdf:Description rdf:about=\"" + this.subject + "\">";
                    ss += "\n";
                    ss += "<dis:" + this.pred + ">" +this.obj + "</dis:" + this.pred + " >";
                    ss += "\n";
                    ss += "</rdf:Description>";
                    ss += "\n\n";
                    output1.Write(ss);                  
                    output1.WriteLine();            

                output1.WriteLine("</rdf:RDF>"); 

            }
        }


        public void GenertateRDF(string sentence)
        {

            #region vars

            int i = 0;
            int pp = 0;

            subject = "";
            subjjj = new List<string>();
            pred = new StringBuilder();
            obj = new List<string>();
            objjj = new List<string>();
            string tem = "";
            int count = 0;

            #endregion vars

            List<int> l = new List<int>();

            string[] sentences = SplitSentences(sentence);
            sentences[0] = sentences[0].Replace("can't", "can");
            sentences[0] = sentences[0].Replace("Excuse me", "");
            sentences[0] = sentences[0].Replace("excuse me", "");
            sentences[0] = sentences[0].Replace("<i>", "");
            sentences[0] = sentences[0].Replace("</i>", "");

            string[] tokens = TokenizeSentence(sentences[0]);

            string[] tags = PosTagTokens(tokens);

            for (int z = 0; z < tokens.Length; z++)
                if (tokens[z].Equals("not") || tokens[z].Equals("n't"))
                    if (tags[z + 1].Equals("VB"))
                    {
                        l.Add(z);
                        l.Add(z - 1);
                    }
                    else
                        l.Add(z);

            int len = l.Count;

            string[] tokens1 = new string[tokens.Length - len];
            string[] tags1 = new string[tokens.Length - len];////////////***********tokens


            int h = 0;
            for (int j = 0; j < tokens.Length; j++)
            {
                if (!l.Contains(j))
                {
                    tokens1[h] = tokens[j];
                    tags1[h] = tags[j];
                    h++;
                }

            }

            tokens1 = Shortcuts(tokens1, tags1);


        #endregion sentence

            #region GetSVO

            subjjj.Clear();
            objjj.Clear();
            pred.Clear();
            obj.Clear();

            subject = Get_sub(tokens1, tags1, pred);
            if (tags1.Length == 1 && tags1[0].Equals("JJ"))
            {
                objjj.Add(tokens1[0]);
            }

            #endregion GetSVO

        }
       
    }





}
