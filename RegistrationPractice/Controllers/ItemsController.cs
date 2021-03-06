﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegistrationPractice.Entities;
using RegistrationPractice.Models;
using System.IO;
using RegistrationPractice.HelperMethods;
using Microsoft.AspNet.Identity;
using Classes.Profanity.Logic;
using PagedList;
using RegistrationPractice.Classes;

namespace RegistrationPractice.Controllers
{
    public class ItemsController : Controller
    {
        
        private static string servername = System.Configuration.ConfigurationManager.AppSettings["servername"];
        

        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly ProfanityFilter pf = new ProfanityFilter(new List<string>
        {
            "5hit","a55","anal","anus","ar5e","arrse","arse","ass","ass-fucker","asses","assfucker","assfukka","asshole","assholes","asswhole","a_s_s","b!tch","b00bs","b17ch","b1tch","ballbag","balls","ballsack","bastard","beastial","beastiality","bellend","bestial","bestiality","bi+ch","biatch","bitch","bitcher","bitchers","bitches","bitchin","bitching","bloody","blow job","blowjob","blowjobs","boiolas","bollock","bollok","boner","boob","boobs","booobs","boooobs","booooobs","booooooobs","breasts","buceta","bugger","bum","bunny fucker","butt","butthole","buttmuch","buttplug","c0ck","c0cksucker","carpet muncher","cawk","chink","cipa","cl1t","clit","clitoris","clits","cnut","cock","cock-sucker","cockface","cockhead","cockmunch","cockmuncher","cocks","cocksuck","cocksucked","cocksucker","cocksucking","cocksucks","cocksuka","cocksukka","cok","cokmuncher","coksucka","coon","cox","crap","cum","cummer","cumming","cums","cumshot","cunilingus","cunillingus","cunnilingus","cunt","cuntlick","cuntlicker","cuntlicking","cunts","cyalis","cyberfuc","cyberfuck","cyberfucked","cyberfucker","cyberfuckers","cyberfucking","d1ck","damn","dick","dickhead","dildo","dildos","dink","dinks","dirsa","dlck","dog-fucker","doggin","dogging","donkeyribber","doosh","duche","dyke","ejaculate","ejaculated","ejaculates","ejaculating","ejaculatings","ejaculation","ejakulate","f u c k","f u c k e r","f4nny","fag","fagging","faggitt","faggot","faggs","fagot","fagots","fags","fanny","fannyflaps","fannyfucker","fanyy","fatass","fcuk","fcuker","fcuking","feck","fecker","felching","fellate","fellatio","fingerfuck","fingerfucked","fingerfucker","fingerfuckers","fingerfucking","fingerfucks","fistfuck","fistfucked","fistfucker","fistfuckers","fistfucking","fistfuckings","fistfucks","flange","fook","fooker","fuck","fucka","fucked","fucker","fuckers","fuckhead","fuckheads","fuckin","fucking","fuckings","fuckingshitmotherfucker","fuckme","fucks","fuckwhit","fuckwit","fudge packer","fudgepacker","fuk","fuker","fukker","fukkin","fuks","fukwhit","fukwit","fux","fux0r","f_u_c_k","gangbang","gangbanged","gangbangs","gaylord","gaysex","goatse","god-dam","god-damned","goddamn","goddamned","hardcoresex","hell","heshe","hoar","hoare","hoer","homo","hore","horniest","horny","hotsex","jack-off","jackoff","jap","jerk-off","jism","jiz","jizm","jizz","kawk","knob","knobead","knobed","knobend","knobhead","knobjocky","knobjokey","kock","kondum","kondums","kum","kummer","kumming","kums","kunilingus","l3i+ch","l3itch","labia","lmfao","lust","lusting","m0f0","m0fo","m45terbate","ma5terb8","ma5terbate","masochist","master-bate","masterb8","masterbat*","masterbat3","masterbate","masterbation","masterbations","masturbate","mo-fo","mof0","mofo","mothafuck","mothafucka","mothafuckas","mothafuckaz","mothafucked","mothafucker","mothafuckers","mothafuckin","mothafucking","mothafuckings","mothafucks","mother fucker","motherfuck","motherfucked","motherfucker","motherfuckers","motherfuckin","motherfucking","motherfuckings","motherfuckka","motherfucks","muff","mutha","muthafecker","muthafuckker","muther","mutherfucker","n1gga","n1gger","nazi","nigg3r","nigg4h","nigga","niggah","niggas","niggaz","nigger","niggers","nob","nob jokey","nobhead","nobjocky","nobjokey","numbnuts","nutsack","orgasim","orgasims","orgasm","orgasms","p0rn","pawn","pecker","penis","penisfucker","phonesex","phuck","phuk","phuked","phuking","phukked","phukking","phuks","phuq","pigfucker","pimpis","piss","pissed","pisser","pissers","pisses","pissflaps","pissin","pissing","pissoff","poop","porn","porno","pornography","pornos","prick","pricks","pron","pube","pusse","pussi","pussies","pussy","pussys","rectum","retard","rimjaw","rimming","s hit","s.o.b.","sadist","schlong","screwing","scroat","scrote","scrotum","semen","sex","sh!+","sh!t","sh1t","shag","shagger","shaggin","shagging","shemale","shi+","shit","shitdick","shite","shited","shitey","shitfuck","shitfull","shithead","shiting","shitings","shits","shitted","shitter","shitters","shitting","shittings","shitty","skank","slut","sluts","smegma","smut","snatch","son-of-a-bitch","spac","spunk","s_h_i_t","t1tt1e5","t1tties","teets","teez","testical","testicle","tit","titfuck","tits","titt","tittie5","tittiefucker","titties","tittyfuck","tittywank","titwank","tosser","turd","tw4t","twat","twathead","twatty","twunt","twunter","v14gra","v1gra","vagina","viagra","vulva","w00se","wang","wank","wanker","wanky","whoar","whore","willies","willy","xrated","xxx","bollocks","child-fucker","Christ on a bike","Christ on a cracker","swear word","godsdamn","holy shit","Jesus","Jesus Christ","Jesus H. Christ","Jesus Harold Christ","Jesus wept","Jesus, Mary and Joseph","Judas Priest","shit ass","shitass","son of a bitch","son of a motherless goat","son of a whore","sweet Jesus","2g1c","2 girls 1 cup","acrotomophilia","alabama hot pocket","alaskan pipeline","anilingus","apeshit","arsehole","assmunch","auto erotic","autoerotic","babeland","baby batter","baby juice","ball gag","ball gravy","ball kicking","ball licking","ball sack","ball sucking","bangbros","bareback","barely legal","barenaked","bastardo","bastinado","bbw","bdsm","beaner","beaners","beaver cleaver","beaver lips","big black","big breasts","big knockers","big tits","bimbos","birdlock","black cock","blonde action","blonde on blonde action","blow your load","blue waffle","blumpkin","bondage","booty call","brown showers","brunette action","bukkake","bulldyke","bullet vibe","bullshit","bung hole","bunghole","busty","buttcheeks","camel toe","camgirl","camslut","camwhore","carpetmuncher","chocolate rosebuds","circlejerk","cleveland steamer","clover clamps","clusterfuck","coprolagnia","coprophilia","cornhole","coons","creampie","darkie","date rape","daterape","deep throat","deepthroat","dendrophilia","dingleberry","dingleberries","dirty pillows","dirty sanchez","doggie style","doggiestyle","doggy style","doggystyle","dog style","dolcett","domination","dominatrix","dommes","donkey punch","double dong","double penetration","dp action","dry hump","dvda","eat my ass","ecchi","erotic","erotism","escort","eunuch","fecal","felch","feltch","female squirting","femdom","figging","fingerbang","fingering","fisting","foot fetish","footjob","frotting","fuck buttons","fucktards","futanari","gang bang","gay sex","genitals","giant cock","girl on","girl on top","girls gone wild","goatcx","god damn","gokkun","golden shower","goodpoop","goo girl","goregasm","grope","group sex","g-spot","guro","hand job","handjob","hard core","hardcore","hentai","homoerotic","honkey","hooker","hot carl","hot chick","how to kill","how to murder","huge fat","humping","incest","intercourse","jack off","jail bait","jailbait","jelly donut","jerk off","jigaboo","jiggaboo","jiggerboo","juggs","kike","kinbaku","kinkster","kinky","knobbing","leather restraint","leather straight jacket","lemon party","lolita","lovemaking","make me come","male squirting","menage a trois","milf","missionary position","mound of venus","mr hands","muff diver","muffdiving","nambla","nawashi","negro","neonazi","nig nog","nimphomania","nipple","nipples","nsfw images","nude","nudity","nympho","nymphomania","octopussy","omorashi","one cup two girls","one guy one jar","orgy","paedophile","paki","panties","panty","pedobear","pedophile","pegging","phone sex","piece of shit","piss pig","pisspig","playboy","pleasure chest","pole smoker","ponyplay","poof","poon","poontang","punany","poop chute","poopchute","prince albert piercing","pthc","pubes","queaf","queef","quim","raghead","raging boner","rape","raping","rapist","reverse cowgirl","rimjob","rosy palm","rosy palm and her 5 sisters","rusty trombone","sadism","santorum","scat","scissoring","sexo","sexy","shaved beaver","shaved pussy","shibari","shitblimp","shota","shrimping","skeet","slanteye","s&m","snowballing","sodomize","sodomy","spic","splooge","splooge moose","spooge","spread legs","strap on","strapon","strappado","strip club","style doggy","suck","sucks","suicide girls","sultry women","swastika","swinger","tainted love","taste my","tea bagging","threesome","throating","tied up","tight white","titty","tongue in a","topless","towelhead","tranny","tribadism","tub girl","tubgirl","tushy","twink","twinkie","two girls one cup","undressing","upskirt","urethra play","urophilia","venus mound","vibrator","violet wand","vorarephilia","voyeur","wetback","wet dream","white power","wrapping men","wrinkled starfish","xx","yaoi","yellow showers","yiffy","zoophilia","a54","buttmunch","donkeypunch","fleshflute","asswipe","ho","bitchass","moo moo foo foo","trumped","assbag","assbandit","assbanger","assbite","assclown","asscock","asscracker","assface","assfuck","assgoblin","asshat","ass-hat","asshead","asshopper","ass-jabber","assjacker","asslick","asslicker","assmonkey","assmuncher","assnigger","asspirate","ass-pirate","assshit","assshole","asssucker","asswad","axwound","bampot","bitchtits","bitchy","bollox","brotherfucker","bumblefuck","butt plug","buttfucka","butt-pirate","buttfucker","chesticle","chinc","choad","chode","clitface","clitfuck","cockass","cockbite","cockburger","cockfucker","cockjockey","cockknoker","cockmaster","cockmongler","cockmongruel","cockmonkey","cocknose","cocknugget","cockshit","cocksmith","cocksmoke","cocksmoker","cocksniffer","cockwaffle","coochie","coochy","cooter","cracker","cumbubble","cumdumpster","cumguzzler","cumjockey","cumslut","cumtart","cunnie","cuntass","cuntface","cunthole","cuntrag","cuntslut","dago","deggo","dickbag","dickbeaters","dickface","dickfuck","dickfucker","dickhole","dickjuice","dickmilk","dickmonger","dicks","dickslap","dick-sneeze","dicksucker","dicksucking","dicktickler","dickwad","dickweasel","dickweed","dickwod","dike","dipshit","doochbag","dookie","douche","douchebag","douche-fag","douchewaffle","dumass","dumb ass","dumbass","dumbfuck","dumbshit","dumshit","fagbag","fagfucker","faggit","faggotcock","fagtard","flamer","fuckass","fuckbag","fuckboy","fuckbrain","fuckbutt","fuckbutter","fuckersucker","fuckface","fuckhole","fucknut","fucknutt","fuckoff","fuckstick","fucktard","fucktart","fuckup","fuckwad","fuckwitt","gay","gayass","gaybob","gaydo","gayfuck","gayfuckist","gaytard","gaywad","goddamnit","gooch","gook","gringo","guido","hard on","heeb","hoe","homodumbshit","jackass","jagoff","jerkass","jungle bunny","junglebunny","kooch","kootch","kraut","kunt","kyke","lameass","lardass","lesbian","lesbo","lezzie","mcfagget","mick","minge","muffdiver","munging","nigaboo","niglet","nut sack","panooch","peckerhead","penisbanger","penispuffer","pissed off","polesmoker","pollock","poonani","poonany","porch monkey","porchmonkey","punanny","punta","pussylicking","puto","queer","queerbait","queerhole","renob","ruski","sand nigger","sandnigger","shitbag","shitbagger","shitbrains","shitbreath","shitcanned","shitcunt","shitface","shitfaced","shithole","shithouse","shitspitter","shitstain","shittiest","shiz","shiznit","skullfuck","slutbag","smeg","spick","spook","suckass","tard","thundercunt","twatlips","twats","twatwaffle","unclefucker","vag","vajayjay","va-j-j","vjayjay","wankjob","whorebag","whoreface","wop","fuck you","piss off","dick head","bloody hell","crikey","rubbish","taking the piss","jerk","knob end","lmao","omg","wtf","bint","ginger","git","minger","munter","sod off","chinky","choc ice","gippo","golliwog","hun","iap","jock","nig-nog","pikey","polack","sambo","slope","spade","taff","wog","beaver","beef curtains","bloodclaat","clunge","flaps","gash","punani","batty boy","bender","bum boy","bumclat","bummer","chi-chi man","chick with a dick","fudge-packer","gender bender","he-she","lezza/lesbo","pansy","shirt lifter","cretin","cripple","div","looney","midget","mong","nutter","psycho","schizo","veqtable","window licker","fenian","kafir","prod","taig","yid","iberian slap","middle finger","two fingers with tongue","two fingers","nonce","prickteaser","rapey","slag","tart","coffin dodger","old bag","frenchify","bescumber","microphallus","coccydynia","ninnyhammer","buncombe","hircismus","corpulent","feist","fice","cacafuego","ass fuck","assfaces","assmucus","bang (one's) box","bastards","beef curtain","bitch tit","blow me","blow mud","blue waffle","blumpkin","bust a load","butt fuck","choade","chota bags","clit licker","clitty litter","cock pocket","cock snot","cocksuck","cocksucked","cocksuckers","cocksucks","cop some wood","cornhole","corp whore","cum chugger","cum dumpster","cum freak","cum guzzler","cumdump","cunt hair","cuntbag","cuntlick","cuntlicker","cuntlicking","cuntsicle","cunt-struck","cut rope","cyberfuck","cyberfucked","cyberfucking","dick hole","dick shy","dickheads","dirty Sanchez","eat a dick","eat hair pie","ejaculates","ejaculating","facial","faggots","fingerfuck","fingerfucked","fingerfucker","fingerfucking","fingerfucks","fist fuck","fistfucked","fistfucker","fistfuckers","fistfucking","fistfuckings","fistfucks","flog the log","fuc","fuck hole","fuck puppet","fuck trophy","fuck yo mama","fuck","fuck-ass","fuck-bitch","fuckedup","fuckme","fuckmeat","fucktoy","fukkers","fuq","gang-bang","gassy ass","god","ham flap","how to murdep","jackasses","jiz","jizm","kinky Jesus","kwif","LEN","mafugly","mothafucked","mothafucking","mother fucker","muff puff","need the dick","nut butter","pisses","pissin","pissoff","pussy fart","pussy palace","queaf","sandbar","sausage queen","shit fucker","shitheads","shitters","shittier","slope","slut bucket","smartass","smartasses","tit wank","tities","wiseass","wiseasses","boong","coonnass","darn","Breeder","Cocklump","Doublelift","Dumbcunt","Fuck off","Poopuncher","Sandler","cockeye","crotte","cus","foah","fucktwat","jaggi","kunja","pust","sanger","seks","zubb","zibbi"
        });

        //allan rodkin

        public async Task<ActionResult> UserPosts()
        {
            string useremail = (string)System.Web.HttpContext.Current.Session["UserEmail"];
            var items = db.Items.Where(i => i.OwnerUserEmail == useremail);
            return View(await items.ToListAsync());
        }

        // GET: Items
        [AllowAnonymous]
        public async Task<ActionResult> Index(string categoryfilter, string SearchTerm, int? LocationId, int? CategoryId, int? PostTypeId, string cancel)
        {
            var items = db.Items.Include(i => i.Category).Include(i => i.Location);
            if (string.IsNullOrEmpty(cancel))
            {

                if (!String.IsNullOrEmpty(SearchTerm))

                {
                    items = items.Where(i => i.Description.ToUpper().Contains(SearchTerm.ToUpper())
                    || i.AdditionalNotes.ToUpper().Contains(SearchTerm.ToUpper())
                );
                }

                if (LocationId.HasValue)
                {
                   

                    items = from itemlist in items.Where(i => i.LocationID == LocationId) select itemlist;
                    int count = (from itemlist in items.Where(i => i.LocationID == LocationId) select itemlist).Count();

                }
                
                if (PostTypeId.HasValue)
                {
                    items = from itemlist in items.Where(i => i.PostTypeID == PostTypeId) select itemlist;
                    int count = (from itemlist in items.Where(i => i.PostTypeID == PostTypeId) select itemlist).Count();
                }

                if (categoryfilter != null)
                {
                    items = items.Where(i => i.CategoryID == CategoryId);
                }
            }


            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryText");
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "LocationText");
            ViewBag.PostTypeID = new SelectList(db.PostTypes, "Id", "PostTypeText");
            return View(await items.ToListAsync());
        }

        // GET: Items/Details/5
        [RequiresRouteValuesAttribute("id")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);

             
            string useremail = (string)System.Web.HttpContext.Current.Session["UserEmail"];
            if (useremail!=null)
            { 
                if (useremail != item.OwnerUserEmail)
                    item.Visits++; 
            }

            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {

            Item item = new Item();

            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryText");
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "LocationText");
            ViewBag.PostTypeID = new SelectList(db.PostTypes, "Id", "PostTypeText");

            //allan rodkin. this should be replaced with session variable
            string useremail = (string)System.Web.HttpContext.Current.Session["UserEmail"];
           
            
            if (useremail == null)
            {
                try
                {
                    var path = Server.MapPath(@"~/log.txt");
                    System.IO.File.WriteAllText(path, "No user email for post");
                    return RedirectToAction("Login", "Account", null);
                }
                catch (Exception e)
                {
                    
                }
            }


            item.OwnerUserEmail = useremail;
            //
            item.EmailRelayAddress = "";
            item.CreationDate = System.DateTime.Now;
            item.Visits = 0;
            item.Returned = false;
            item.HideItem = false;


            return View("Create", item);
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,LostOrFoundItem,NoReward,ItemReward,Description,LocationID,CategoryID,CreationDate,EmailRelayAddress,AdditionalNotes,Visits,Returned,OwnerUserEmail,imageURL,imageTitle,HideItem,PostTypeID")] Item item, HttpPostedFileBase files)
        {

            //allan rodkin image code
            if (files != null)
            {

                string time = DateTime.UtcNow.ToString();
                time = time.Replace(" ", "-");
                time = time.Replace(":", "-");
                time = time.Replace("/", "-");
                try
                {

                    string[] extensions = new string[] { ".jpg", ".png" };
                    //throw new Exception("blah");
                    var filename = Path.GetFileName(time + Path.GetFileName(files.FileName));
                    var checkextension = Path.GetExtension(files.FileName).ToLower();
                    var filesize = (files.ContentLength / 1048576 );
                    if (filesize > 5)
                    {
                        throw new Exception("File cannot be saved. Max file extension is 5MB");
                    }
                    if (!extensions.Contains(checkextension))
                    {
                        throw new Exception("File cannot be saved. Invalid extension.");
                    }

                    var path = Path.Combine(Server.MapPath("~/photos"), filename);
                    string[] paths = path.Split('.');
                    string filetype = paths[1];

                    string fullpath = String.Format("{0}.{1}", paths[0], paths[1]);
                    files.SaveAs(fullpath);
                    item.imageURL = servername + "/photos/" + filename;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                }

            }
            if (ModelState.IsValid)
            {
                //profanity check
                bool textContainsProfanity = pf.ValidateTextContainsProfanity(item.Description);
                if (textContainsProfanity)
                {
                    //item.Description = pf.CleanTextProfanity(item.Description);
                    ViewBag.Message = "Post contains profanity. Cannot submit.";
                    return View("Profanity");
                }

               

                db.Items.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
           
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryText", item.CategoryID);
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "LocationText", item.LocationID);
            ViewBag.PostTypeID = new SelectList(db.PostTypes, "Id", "PostTypeText", item.PostTypeID);
            return View(item);
        }

        // GET: Items/Edit/5
        
        public async Task<ActionResult> Edit(int? id)
        {
            
            string useremail = (string)System.Web.HttpContext.Current.Session["UserEmail"];

            Item item = await db.Items.FindAsync(id);


            if (item!=null && useremail != null && useremail != item.OwnerUserEmail)
            {
                TempData["Message"] = "You do not have permission to modify this post.";
                return RedirectToAction("Index", "Items", null);
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            

            
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryText", item.CategoryID);
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "LocationText", item.LocationID);
            if (item.imageURL != null) ViewBag.ImageUrl = item.imageURL;
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<ActionResult> Edit([Bind(Include = "Id,LostOrFoundItem,NoReward,ItemReward,Description,LocationID,CategoryID,CreationDate,EmailRelayAddress,AdditionalNotes,Visits,Returned,OwnerUserEmail,imageURL,imageTitle,HideItem, PostTypeId")] Item item, HttpPostedFileBase files)
        {

            //allan rodkin image code
            if (files != null)
            {
                string time = DateTime.UtcNow.ToString();
                time = time.Replace(" ", "-");
                time = time.Replace(":", "-");
                time = time.Replace("/", "-");
                try
                {

                    string[] extensions = new string[] { ".jpg", ".png" };
                    //throw new Exception("blah");
                    var filename = Path.GetFileName(time + Path.GetFileName(files.FileName));
                    var checkextension = Path.GetExtension(files.FileName).ToLower();
                    var filesize = (files.ContentLength / 1048576);
                    if (filesize > 5)
                    {
                        throw new Exception("File cannot be saved. Max file extension is 5MB");
                    }
                    if (!extensions.Contains(checkextension))
                    {
                        throw new Exception("File cannot be saved. Invalid extension.");
                    }

                    var path = Path.Combine(Server.MapPath("~/photos"), filename);
                    string[] paths = path.Split('.');
                    string filetype = paths[1];

                    string fullpath = String.Format("{0}.{1}", paths[0], paths[1]);
                    files.SaveAs(fullpath);
                    string servername = System.Configuration.ConfigurationManager.AppSettings["servername"];
                    item.imageURL = servername + "/photos/" + filename;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                }
            }
                

            
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                //profanity check
                bool textContainsProfanity = pf.ValidateTextContainsProfanity(item.Description);
                if (textContainsProfanity)
                {
                    //item.Description = pf.CleanTextProfanity(item.Description);
                    Item item2 = await db.Items.FindAsync(item.Id);
                    db.Items.Remove(item2);
                    await db.SaveChangesAsync();

                    ViewBag.Message = "Post contains profanity. Cannot submit.";
                    return View("Profanity");
                }

                //allan rodkin
                item.PostType = new PostType();
                item.PostType.PostTypeText = db.PostTypes.SingleOrDefault(pt => pt.Id == item.PostTypeID).PostTypeText;


                
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryText", item.CategoryID);
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "LocationText", item.LocationID);
            ViewBag.PostTypeID = new SelectList(db.PostTypes, "Id", "PostTypeText", item.PostTypeID);
            return View(item);
        }

        // GET: Items/Delete/5
        
        public async Task<ActionResult> Delete(int? id)
        {
            string useremail = (string)System.Web.HttpContext.Current.Session["UserEmail"];

            Item item = await db.Items.FindAsync(id);

            if (item != null && useremail != null && useremail != item.OwnerUserEmail)
            {
                TempData["Message"] = "You do not have permission to modify this post.";
                return RedirectToAction("Index", "Items", null);
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [RequiresRouteValuesAttribute("id")]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            Item item = await db.Items.FindAsync(id);
            db.Items.Remove(item);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
