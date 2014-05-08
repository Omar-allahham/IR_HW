using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
//using System.Windows.Forms;

namespace IR_HW
{
    class IrRegular
    {
        #region Var
        public  string v1 = "";
       public string v2 = "";
       public string v3 = "";
       public List<IrRegular> a = new List<IrRegular>();
       public List<IrRegular> b = new List<IrRegular>();
       public List<IrRegular> c = new List<IrRegular>();
       public List<IrRegular> d = new List<IrRegular>();
       public List<IrRegular> e = new List<IrRegular>();
       public List<IrRegular> f = new List<IrRegular>();
       public List<IrRegular> g = new List<IrRegular>();
       public List<IrRegular> h = new List<IrRegular>();
       public List<IrRegular> i = new List<IrRegular>();
       public List<IrRegular> j = new List<IrRegular>();
       public List<IrRegular> k = new List<IrRegular>();
       public List<IrRegular> l = new List<IrRegular>();
       public List<IrRegular> m = new List<IrRegular>();
       public List<IrRegular> n = new List<IrRegular>();
       public List<IrRegular> o = new List<IrRegular>();
       public List<IrRegular> p = new List<IrRegular>();
       public List<IrRegular> q = new List<IrRegular>();
       public List<IrRegular> r = new List<IrRegular>();
       public List<IrRegular> s = new List<IrRegular>();
       public List<IrRegular> t = new List<IrRegular>();
       public List<IrRegular> u = new List<IrRegular>();
       public List<IrRegular> v = new List<IrRegular>();
       public List<IrRegular> w = new List<IrRegular>();
        #endregion Var


     
     void   Irregularverbs(string v1,string v2,string v3) 
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }



     public void getIrregularverbs() 
     {
         
         string[] lines = System.IO.File.ReadAllLines(@"\Irregularverb\a.txt");
         for (int i = 0; i < lines.Length; i++)
         {//MessageBox.Show(lines[0]);
             IrRegular r = cut(lines[i]);
             a.Add(r);
             //MessageBox.Show(a[i].v1 + " " + a[i].v2 + " " + a[i].v3);
         }



          lines = System.IO.File.ReadAllLines(@"\Irregularverb\b.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              b.Add(r);
              //MessageBox.Show(b[i].v1 + " " + b[i].v2 + " " + b[i].v3);
          }




          lines = System.IO.File.ReadAllLines(@"\Irregularverb\c.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              c.Add(r);
              //MessageBox.Show(c[i].v1 + " " + c[i].v2 + " " + c[i].v3);
          }



          lines = System.IO.File.ReadAllLines(@"\Irregularverb\d.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              d.Add(r);
              //MessageBox.Show(d[i].v1 + " " + d[i].v2 + " " + d[i].v3);
          }



          lines = System.IO.File.ReadAllLines(@"\Irregularverb\e.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              e.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }



          lines = System.IO.File.ReadAllLines(@"\Irregularverb\f.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              f.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }

         
         
         lines = System.IO.File.ReadAllLines(@"\Irregularverb\g.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              g.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }
         
         
         
         lines = System.IO.File.ReadAllLines(@"\Irregularverb\h.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              h.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }
         
         
         
         lines = System.IO.File.ReadAllLines(@"\Irregularverb\i.txt");
          for (int ii = 0; ii < lines.Length; ii++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[ii]);
              i.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }
         
         
         
         lines = System.IO.File.ReadAllLines(@"\Irregularverb\j.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              j.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }
         
         
         
         lines = System.IO.File.ReadAllLines(@"\Irregularverb\k.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              k.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }
         
         
         
         lines = System.IO.File.ReadAllLines(@"\Irregularverb\l.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              l.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }
         
         
         
         lines = System.IO.File.ReadAllLines(@"\Irregularverb\m.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              m.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }


          lines = System.IO.File.ReadAllLines(@"\Irregularverb\n.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              n.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }
         
         
         lines = System.IO.File.ReadAllLines(@"\Irregularverb\o.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              o.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }
         
         
         
         
         lines = System.IO.File.ReadAllLines(@"\Irregularverb\p.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              p.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }
         
         
         
         lines = System.IO.File.ReadAllLines(@"\Irregularverb\q.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              q.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }
         
         
         
         
         lines = System.IO.File.ReadAllLines(@"\Irregularverb\r.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular rr = cut(lines[i]);
              r.Add(rr);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }
         
         
         
         lines = System.IO.File.ReadAllLines(@"\Irregularverb\s.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              s.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }
         
         
         
         lines = System.IO.File.ReadAllLines(@"\Irregularverb\t.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              t.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }
         
         
         
         lines = System.IO.File.ReadAllLines(@"\Irregularverb\u.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              u.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }


          lines = System.IO.File.ReadAllLines(@"\Irregularverb\v.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              v.Add(r);
              //MessageBox.Show(e[i].v1 + " " + e[i].v2 + " " + e[i].v3);
          }
         
         
         lines = System.IO.File.ReadAllLines(@"\Irregularverb\w.txt");
          for (int i = 0; i < lines.Length; i++)
          {//MessageBox.Show(lines[0]);
              IrRegular r = cut(lines[i]);
              w.Add(r);
              //MessageBox.Show(w[i].v1 + " " + w[i].v2 + " " + w[i].v3);
          }
         // MessageBox.Show("ok");
     }



     public IrRegular cut(string s) 
     {
         IrRegular r = new IrRegular();
         int count=0;
         for (int i = 0; i < s.Length; i++) 
         {
             if (count == 0 && s[i] != ';')
             {
                 r.v1 += s[i];
             }
             else if ( s[i] == ';') count++;
             if (count == 1 && s[i] != ';')
             {
                 r.v2 += s[i];
             }
             //else if (count == 1 && s[i]==';') count++;
             if (count == 2 && s[i] != ';')
             {
                 r.v3 += s[i];
             }
             //else if(count ==2 && s[i]==';')
            
         }
       return r;
     }




     public string getInfinitive(string verb) 
     {
         string infinitive = "";
         if (verb[0] == 'a') 
         {
             for (int i = 0; i < a.Count; i++) 
             {
                 if (verb.Equals(a[i].v1)) 
                 {
                     infinitive = a[i].v1;
                     break;
                 }
                 else if (verb.Equals(a[i].v2))
                 {
                     infinitive = a[i].v1;
                     break;
                 }
                 else if (verb.Equals(a[i].v3))
                 {
                     infinitive = a[i].v1;
                     break;
                 }
             }
         }
         else if (verb[0] == 'b')
         {
             for (int i = 0; i < b.Count; i++)
             {
                 if (verb.Equals(b[i].v1))
                 {
                     infinitive = b[i].v1;
                     break;
                 }
                 else if (verb.Equals(b[i].v2))
                 {
                     infinitive = b[i].v1;
                     break;
                 }
                 else if (verb.Equals(b[i].v3))
                 {
                     infinitive = b[i].v1;
                     break;
                 }
             }
         }///end of status

         else if (verb[0] == 'c')
         {
             for (int i = 0; i < c.Count; i++)
             {
                 if (verb.Equals(c[i].v1))
                 {
                     infinitive = c[i].v1;
                     break;
                 }
                 else if (verb.Equals(c[i].v2))
                 {
                     infinitive = c[i].v1;
                     break;
                 }
                 else if (verb.Equals(c[i].v3))
                 {
                     infinitive = c[i].v1;
                     break;
                 }
             }
         }///end of status
         else if (verb[0] == 'd')
         {
             for (int i = 0; i < d.Count; i++)
             {
                 if (verb.Equals(d[i].v1))
                 {
                     infinitive = d[i].v1;
                     break;
                 }
                 else if (verb.Equals(d[i].v2))
                 {
                     infinitive = d[i].v1;
                     break;
                 }
                 else if (verb.Equals(d[i].v3))
                 {
                     infinitive = d[i].v1;
                     break;
                 }
             }
         }///end of status
          ///
         else if (verb[0] == 'e')
         {
             for (int i = 0; i < e.Count; i++)
             {
                 if (verb.Equals(e[i].v1))
                 {
                     infinitive = e[i].v1;
                     break;
                 }
                 else if (verb.Equals(e[i].v2))
                 {
                     infinitive = e[i].v1;
                     break;
                 }
                 else if (verb.Equals(e[i].v3))
                 {
                     infinitive = e[i].v1;
                     break;
                 }
             }
         }///end of status
         else if (verb[0] == 'f')
         {
             for (int i = 0; i < f.Count; i++)
             {
                 if (verb.Equals(f[i].v1))
                 {
                     infinitive = f[i].v1;
                     break;
                 }
                 else if (verb.Equals(f[i].v2))
                 {
                     infinitive = f[i].v1;
                     break;
                 }
                 else if (verb.Equals(f[i].v3))
                 {
                     infinitive = f[i].v1;
                     break;
                 }
             }
         }///end of status
          ///
         else if (verb[0] == 'g')
         {
             for (int i = 0; i < g.Count; i++)
             {
                 if (verb.Equals(g[i].v1))
                 {
                     infinitive = g[i].v1;
                     break;
                 }
                 else if (verb.Equals(g[i].v2))
                 {
                     infinitive = g[i].v1;
                     break;
                 }
                 else if (verb.Equals(g[i].v3))
                 {
                     infinitive = g[i].v1;
                     break;
                 }
             }
         }///end of status
          ///
         else if (verb[0] == 'h')
         {
             for (int i = 0; i < h.Count; i++)
             {
                 if (verb.Equals(h[i].v1))
                 {
                     infinitive = h[i].v1;
                     break;
                 }
                 else if (verb.Equals(h[i].v2))
                 {
                     infinitive = h[i].v1;
                     break;
                 }
                 else if (verb.Equals(h[i].v3))
                 {
                     infinitive = h[i].v1;
                     break;
                 }
             }
         }///end of status
          ///
         else if (verb[0] == 'i')
         {
             for (int ii = 0; ii < i.Count; ii++)
             {
                 if (verb.Equals(i[ii].v1))
                 {
                     infinitive = i[ii].v1;
                     break;
                 }
                 else if (verb.Equals(i[ii].v2))
                 {
                     infinitive = i[ii].v1;
                     break;
                 }
                 else if (verb.Equals(i[ii].v3))
                 {
                     infinitive = i[ii].v1;
                     break;
                 }
             }
         }///end of status
          ///
         else if (verb[0] == 'j')
         {
             for (int i = 0; i < j.Count; i++)
             {
                 if (verb.Equals(j[i].v1))
                 {
                     infinitive = j[i].v1;
                     break;
                 }
                 else if (verb.Equals(j[i].v2))
                 {
                     infinitive = j[i].v1;
                     break;
                 }
                 else if (verb.Equals(j[i].v3))
                 {
                     infinitive = j[i].v1;
                     break;
                 }
             }
         }///end of status
          ///
         else if (verb[0] == 'k')
         {
             for (int i = 0; i < k.Count; i++)
             {
                 if (verb.Equals(k[i].v1))
                 {
                     infinitive = k[i].v1;
                     break;
                 }
                 else if (verb.Equals(k[i].v2))
                 {
                     infinitive = k[i].v1;
                     break;
                 }
                 else if (verb.Equals(k[i].v3))
                 {
                     infinitive = k[i].v1;
                     break;
                 }
             }
         }///end of status
          ///
         else if (verb[0] == 'l')
         {
             for (int i = 0; i < l.Count; i++)
             {
                 if (verb.Equals(l[i].v1))
                 {
                     infinitive = l[i].v1;
                     break;
                 }
                 else if (verb.Equals(l[i].v2))
                 {
                     infinitive = l[i].v1;
                     break;
                 }
                 else if (verb.Equals(l[i].v3))
                 {
                     infinitive = l[i].v1;
                     break;
                 }
             }
         }///end of status
          ///
         else if (verb[0] == 'm')
         {
             for (int i = 0; i < m.Count; i++)
             {
                 if (verb.Equals(m[i].v1))
                 {
                     infinitive = m[i].v1;
                     break;
                 }
                 else if (verb.Equals(m[i].v2))
                 {
                     infinitive = m[i].v1;
                     break;
                 }
                 else if (verb.Equals(m[i].v3))
                 {
                     infinitive = m[i].v1;
                     break;
                 }
             }
         }///end of status
          ///
         else if (verb[0] == 'n')
         {
             for (int i = 0; i < n.Count; i++)
             {
                 if (verb.Equals(n[i].v1))
                 {
                     infinitive = n[i].v1;
                     break;
                 }
                 else if (verb.Equals(n[i].v2))
                 {
                     infinitive = n[i].v1;
                     break;
                 }
                 else if (verb.Equals(n[i].v3))
                 {
                     infinitive = n[i].v1;
                     break;
                 }
             }
         }///end of status
         ///
         else if (verb[0] == 'o')
         {
             for (int i = 0; i < o.Count; i++)
             {
                 if (verb.Equals(o[i].v1))
                 {
                     infinitive = o[i].v1;
                     break;
                 }
                 else if (verb.Equals(o[i].v2))
                 {
                     infinitive = o[i].v1;
                     break;
                 }
                 else if (verb.Equals(o[i].v3))
                 {
                     infinitive = o[i].v1;
                     break;
                 }
             }
         }///end of status
          ///
         else if (verb[0] == 'p')
         {
             for (int i = 0; i < p.Count; i++)
             {
                 if (verb.Equals(p[i].v1))
                 {
                     infinitive = p[i].v1;
                     break;
                 }
                 else if (verb.Equals(p[i].v2))
                 {
                     infinitive = p[i].v1;
                     break;
                 }
                 else if (verb.Equals(p[i].v3))
                 {
                     infinitive = p[i].v1;
                     break;
                 }
             }
         }///end of status
          ///
         else if (verb[0] == 'q')
         {
             for (int i = 0; i < q.Count; i++)
             {
                 if (verb.Equals(q[i].v1))
                 {
                     infinitive = q[i].v1;
                     break;
                 }
                 else if (verb.Equals(q[i].v2))
                 {
                     infinitive = q[i].v1;
                     break;
                 }
                 else if (verb.Equals(q[i].v3))
                 {
                     infinitive = q[i].v1;
                     break;
                 }
             }
         }///end of status
          ///
         else if (verb[0] == 'r')
         {
             for (int i = 0; i < r.Count; i++)
             {
                 if (verb.Equals(r[i].v1))
                 {
                     infinitive = r[i].v1;
                     break;
                 }
                 else if (verb.Equals(r[i].v2))
                 {
                     infinitive = r[i].v1;
                     break;
                 }
                 else if (verb.Equals(r[i].v3))
                 {
                     infinitive = r[i].v1;
                     break;
                 }
             }
         }///end of status
          ///
         else if (verb[0] == 's')
         {
             for (int i = 0; i < s.Count; i++)
             {
                 if (verb.Equals(s[i].v1))
                 {
                     infinitive = s[i].v1;
                     break;
                 }
                 else if (verb.Equals(s[i].v2))
                 {
                     infinitive = s[i].v1;
                     break;
                 }
                 else if (verb.Equals(s[i].v3))
                 {
                     infinitive = s[i].v1;
                     break;
                 }
             }
         }///end of status
          ///
         else if (verb[0] == 't')
         {
             for (int i = 0; i < t.Count; i++)
             {
                 if (verb.Equals(t[i].v1))
                 {
                     infinitive = t[i].v1;
                     break;
                 }
                 else if (verb.Equals(t[i].v2))
                 {
                     infinitive = t[i].v1;
                     break;
                 }
                 else if (verb.Equals(t[i].v3))
                 {
                     infinitive = t[i].v1;
                     break;
                 }
             }
         }///end of status
          ///
         else if (verb[0] == 'u')
         {
             for (int i = 0; i < u.Count; i++)
             {
                 if (verb.Equals(u[i].v1))
                 {
                     infinitive = u[i].v1;
                     break;
                 }
                 else if (verb.Equals(u[i].v2))
                 {
                     infinitive = u[i].v1;
                     break;
                 }
                 else if (verb.Equals(u[i].v3))
                 {
                     infinitive = u[i].v1;
                     break;
                 }
             }
         }///end of status
          ///
         else if (verb[0] == 'v')
         {
             for (int i = 0; i < v.Count; i++)
             {
                 if (verb.Equals(v[i].v1))
                 {
                     infinitive = v[i].v1;
                     break;
                 }
                 else if (verb.Equals(v[i].v2))
                 {
                     infinitive = v[i].v1;
                     break;
                 }
                 else if (verb.Equals(v[i].v3))
                 {
                     infinitive = v[i].v1;
                     break;
                 }
             }
         }///end of status
         ///
         else if (verb[0] == 'w')
         {
             for (int i = 0; i < w.Count; i++)
             {
                 if (verb.Equals(w[i].v1))
                 {
                     infinitive = w[i].v1;
                     break;
                 }
                 else if (verb.Equals(w[i].v2))
                 {
                     infinitive = w[i].v1;
                     break;
                 }
                 else if (verb.Equals(w[i].v3))
                 {
                     infinitive = w[i].v1;
                     break;
                 }
             }
         }///end of status
        // MessageBox.Show(infinitive);

         return infinitive;
     }
    }
}
