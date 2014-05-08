using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using VDS.RDF;
using Tweetinvi;
using TweetinviCore.Enum;
using System.Text.RegularExpressions;

namespace IR_HW
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Button1_Click(object sender, EventArgs e)
        {
             TwitterCredentials.ApplicationCredentials = TwitterCredentials.CreateCredentials("864454327-V2cBEuLuYM3DZhCUHDJ7HUPJlk5vq3znCmKgdhmS", "XJmioi54rIXdddv2ExUbj5c0p9WtZJtBcici9X1keNIzS", "QEQwBPPnzUvjXBkpNTPrg", "oNShybGlceLotlR9whM76yMHoBNS6c1gPUcidPLaEg");
            var searchParameter = Search.GenerateSearchTweetParameter("");
           searchParameter.SetGeoCode(Double.Parse(Hidden1.Value), Double.Parse(Hidden2.Value), int.Parse(DropDownList1.SelectedValue), DistanceMeasure.Miles);
            searchParameter.Lang = Language.English;
            searchParameter.MaximumNumberOfResults = 100000;
            var tweets = Search.SearchTweets(searchParameter);

          
            StringBuilder SVO = new StringBuilder();
            
            IGraph g = new Graph { BaseUri = new Uri("http://www.dbpedia.org/") };
            g.NamespaceMap.AddNamespace("ex", UriFactory.Create("http://www.dbpedia.org/"));
            foreach (var tweet in tweets)
            {
               
                     TripleSVO Test;
                    string[] TweetText = TripleSVO.SplitSentences(TripleSVO.Cleaning(tweet.Text));
                    for (int i = 0; i < TweetText.Length; i++)
                    {
                        string str = "";
                        Regex rgx = new Regex("[^a-zA-Z -]");
                        str = rgx.Replace(TweetText[i], "");
                        Test = new TripleSVO();
                        Test.GenertateRDF(str, "test");
                        SVO.Append( "  Predicate: " + Test.pred + "  Subject: " + Test.subject + "  Obj:" + ((Test.obj.Count > 0)? Test.obj[0]+"\n":"\n") );
                        if ((Test.obj.Count > 0 )&& !(Test.subject.Equals("")) && !(Test.pred.Equals("")))
                        {
                            IUriNode Subject = g.CreateUriNode("ex:" + Test.subject);
                            IUriNode Predicate = g.CreateUriNode("ex:" + Test.pred.ToString());
                           // IUriNode Subject = g.CreateUriNode(UriFactory.Create(@"http://dbpedia.org/"+ Test.subject));
                            //IUriNode Predicate = g.CreateUriNode(UriFactory.Create(@"http://dbpedia.org/" +  Test.pred.ToString() +tweet.CreatedAt.ToString() + tweet.Coordinates.ToString()));
                            ILiteralNode Object = g.CreateLiteralNode(Test.obj[0]);
                            g.Assert(new Triple(Subject, Predicate, Object));
                         

                        }
                        //Label1.Text = Label1.Text + "Predicate: " + Test.pred + "Subject: " + Test.subject + "Obj: ";                     
                    }

                    // Label1.Text = Label1.Text + tweet.Text;
                }

                
            

              g.SaveToFile(@"D:\testrdf.rdf");
          //  this.Response.Redirect("Target.aspx?info=" + this.TextBox1.Text + "," + this.Hidden1.Value + "," + this.Hidden2.Value + "," + this.DropDownList1.SelectedValue + "," + this.Calendar1.SelectedDate + "," + this.Calendar2.SelectedDate);

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}