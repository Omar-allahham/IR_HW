using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tweetinvi;
using TweetinviCore.Enum;
using VDS.RDF.Query;
using VDS.RDF.Writing;
using System.Text;
using VDS.RDF;
using WordNetClasses;
using Wnlib;
namespace IR_HW
{
    public partial class _Default : System.Web.UI.Page
    {

        //public List<string> get_synonym(string word, string Type)
        //{
        //    //Create process
        //    System.Diagnostics.Process pProcess = new System.Diagnostics.Process();

        //    //strCommand is path and file name of command to run
        //    pProcess.StartInfo.FileName = @"Wordnet\LAIR.exe";

        //    //strCommandParameters are parameters to pass to program
        //    pProcess.StartInfo.Arguments = word + " " + Type;

        //    pProcess.StartInfo.UseShellExecute = false;

        //    //Set output of program to be written to process output stream
        //    pProcess.StartInfo.RedirectStandardOutput = true;

        //    //Optional
        //    pProcess.StartInfo.WorkingDirectory = @"Wordnet";

        //    try
        //    {
        //        //Start the process
        //        pProcess.Start();

        //        //Get program output
        //        string strOutput = pProcess.StandardOutput.ReadToEnd();
        //        List<string> Res_Syn = strOutput.Split('\n').ToList();
        //        //Wait for process to finish
        //        pProcess.WaitForExit();
        //        strOutput = "";
        //        return Res_Syn;
        //    }
        //    catch (Exception ex)
        //    {
        //       // MessageBox.Show(ex.ToString());
        //        return new List<string>();
        //    }



        //}


        protected void Page_Load(object sender, EventArgs e)
        {
           // List<string> Test = get_synonym("hot", "Noun");
         //   Synonym Test = new Synonym("test", 0);
           
		//Define a remote endpoint
		//Use the DBPedia SPARQL endpoint with the default Graph set to DBPedia
		SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        Options.HttpDebugging = true;
     // Options.HttpFullDebugging = true;
		//Make a SELECT query against the Endpoint
       //SparqlResultSet results = endpoint.QueryWithResultSet("select distinct  ?Concept where {[] a ?Concept} LIMIT 100");
       //foreach (SparqlResult result in results)
       //{
       //    Label1.Text = Label1.Text + result.ToString();
       //}
            
          //  Make a DESCRIBE query against the Endpoint
    //    IGraph g = endpoint.QueryWithResultGraph("CONSTRUCT { ?instance a ?class } WHERE { ?instance a ?class }");
       
        try
        {
           // Options.HttpDebugging = true;
            //Options.HttpFullDebugging = true;
            endpoint.RdfAcceptHeader = "application/turtle";
           IGraph g = endpoint.QueryWithResultGraph("CONSTRUCT { ?instance a ?class } WHERE { ?instance a ?class } LIMIT 100");
            //Try your query here
            foreach (Triple t in g.Triples)
            {
                Label1.Text = Label1.Text+"----------"+t.ToString();
            }

        }
        finally
        {
            Options.HttpDebugging = false;
            Options.HttpFullDebugging = false;
        }

      





            //IGraph g = new Graph();
            //IUriNode dotNetRDF = g.CreateUriNode(UriFactory.Create("http://www.dotnetrdf.org"));
            //IUriNode says = g.CreateUriNode(UriFactory.Create("http://example.org/says"));
            //ILiteralNode helloWorld = g.CreateLiteralNode("Hello World");
            //ILiteralNode bonjourMonde = g.CreateLiteralNode("Bonjour tout le Monde", "fr");

            //g.Assert(new Triple(dotNetRDF, says, helloWorld));
            //g.Assert(new Triple(dotNetRDF, says, bonjourMonde));
            //Label1.Text = "First";
            //foreach (Triple t in g.Triples)
            //{
            //    //string temp = Label1.Text + System.Environment.NewLine;
            //    //Label1.Text = temp + t.ToString();
            //    //Label1.Text.Insert(0, System.Environment.NewLine.ToString() + t.ToString());
            //    //Console.WriteLine(t.ToString());
            //}


            //TwitterCredentials.ApplicationCredentials = TwitterCredentials.CreateCredentials("864454327-V2cBEuLuYM3DZhCUHDJ7HUPJlk5vq3znCmKgdhmS", "XJmioi54rIXdddv2ExUbj5c0p9WtZJtBcici9X1keNIzS", "QEQwBPPnzUvjXBkpNTPrg", "oNShybGlceLotlR9whM76yMHoBNS6c1gPUcidPLaEg");
            //var searchParameter = Search.GenerateSearchTweetParameter("");
            //searchParameter.SetGeoCode(-122.398720, 37.781157, 1, DistanceMeasure.Miles);
            //searchParameter.Lang = Language.English;
            //searchParameter.MaximumNumberOfResults = 100000;
            //var tweets = Search.SearchTweets(searchParameter);
            

        //    foreach (var tweet in tweets)
        //    {
                
        //        Label1.Text = Label1.Text + tweet.Text;
                   
                
        //    }
        //    Label1.Text = Label1.Text + tweets.Count.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TwitterCredentials.ApplicationCredentials = TwitterCredentials.CreateCredentials("864454327-V2cBEuLuYM3DZhCUHDJ7HUPJlk5vq3znCmKgdhmS", "XJmioi54rIXdddv2ExUbj5c0p9WtZJtBcici9X1keNIzS", "QEQwBPPnzUvjXBkpNTPrg", "oNShybGlceLotlR9whM76yMHoBNS6c1gPUcidPLaEg");
            var searchParameter = Tweetinvi.Search.GenerateSearchTweetParameter("a");
           // searchParameter.SetGeoCode(-122.398720, 37.781157, 1, DistanceMeasure.Miles);
            searchParameter.Lang = Language.English;
            searchParameter.MaximumNumberOfResults = 100000;
            var tweets = Tweetinvi.Search.SearchTweets(searchParameter);

            int t1 = 0;
            StringBuilder SVO = new StringBuilder();
            IGraph g = new Graph();
            foreach (var tweet in tweets)
            {
                if (t1 < 10 )
                {t1++;
                    TripleSVO Test;
                    string[] TweetText = TripleSVO.SplitSentences(TripleSVO.Cleaning(tweet.Text));
                    for (int i = 0; i < TweetText.Length; i++)
                    {
                        Test = new TripleSVO();
                        Test.GenertateRDF(TweetText[i], "test");
                        SVO.Append( "  Predicate: " + Test.pred + "  Subject: " + Test.subject + "  Obj:" + ((Test.obj.Count > 0)? Test.obj[0]+"\n":"\n") );
                        if (Test.obj.Count > 0 & Test.subject != null & Test.pred != null)
                        {

                            IUriNode Subject = g.CreateUriNode(UriFactory.Create(@"http://dbpedia.org/"+ Test.subject));
                            IUriNode Predicate = g.CreateUriNode(UriFactory.Create(@"http://dbpedia.org/"+Test.pred.ToString()));
                            ILiteralNode Object = g.CreateLiteralNode(Test.obj[0]);


                            g.Assert(new Triple(Subject, Predicate, Object));

                        }
                        //Label1.Text = Label1.Text + "Predicate: " + Test.pred + "Subject: " + Test.subject + "Obj: ";                     
                    }

                    // Label1.Text = Label1.Text + tweet.Text;
                }

                
                Label1.Text = SVO.ToString();

              g.SaveToFile(@"D:\testrdf.rdf");



                //TripleSVO Test = new TripleSVO();

                //    Test.GenertateRDF("anas does not eat a hot dog", "test");
                //    Label1.Text = "Predicate: " + Test.pred + "Subject: " + Test.subject + "Obj: " + Test.obj[0];


                //Test.PrintRDF();
            }
        }
    }
}
