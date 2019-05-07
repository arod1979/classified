using Classes.Profanity.Logic;
using RegistrationPractice.Classes;
using RegistrationPractice.Classes.Globals;
using RegistrationPractice.Entities;
using RegistrationPractice.Filters;
using RegistrationPractice.Models;
using RegistrationPractice.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using CaptchaMvc.HtmlHelpers;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Http.Headers;

namespace RegistrationPractice.Controllers
{

    public class ItemsController : Controller
    {
        private TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        private ApplicationUserManager _userManager;
        public ApplicationDbContext db = new ApplicationDbContext("DefaultConnection");
        private readonly ProfanityFilter pf = new ProfanityFilter(new List<string>
        {
            "mind", "patience","control","temper","virgin","virginity","5hit","a55","anal","anus","ar5e","arrse","arse","ass","ass-fucker","asses","assfucker","assfukka","asshole","assholes","asswhole","a_s_s","b!tch","b00bs","b17ch","b1tch","ballbag","balls","ballsack","bastard","beastial","beastiality","bellend","bestial","bestiality","bi+ch","biatch","bitch","bitcher","bitchers","bitches","bitchin","bitching","bloody","blow job","blowjob","blowjobs","boiolas","bollock","bollok","boner","boob","boobs","booobs","boooobs","booooobs","booooooobs","breasts","buceta","bugger","bum","bunny fucker","butt","butthole","buttmuch","buttplug","c0ck","c0cksucker","carpet muncher","cawk","chink","cipa","cl1t","clit","clitoris","clits","cnut","cock","cock-sucker","cockface","cockhead","cockmunch","cockmuncher","cocks","cocksuck","cocksucked","cocksucker","cocksucking","cocksucks","cocksuka","cocksukka","cok","cokmuncher","coksucka","coon","cox","crap","cum","cummer","cumming","cums","cumshot","cunilingus","cunillingus","cunnilingus","cunt","cuntlick","cuntlicker","cuntlicking","cunts","cyalis","cyberfuc","cyberfuck","cyberfucked","cyberfucker","cyberfuckers","cyberfucking","d1ck","damn","dick","dickhead","dildo","dildos","dink","dinks","dirsa","dlck","dog-fucker","doggin","dogging","donkeyribber","doosh","duche","dyke","ejaculate","ejaculated","ejaculates","ejaculating","ejaculatings","ejaculation","ejakulate","f u c k","f u c k e r","f4nny","fag","fagging","faggitt","faggot","faggs","fagot","fagots","fags","fanny","fannyflaps","fannyfucker","fanyy","fatass","fcuk","fcuker","fcuking","feck","fecker","felching","fellate","fellatio","fingerfuck","fingerfucked","fingerfucker","fingerfuckers","fingerfucking","fingerfucks","fistfuck","fistfucked","fistfucker","fistfuckers","fistfucking","fistfuckings","fistfucks","flange","fook","fooker","fuck","fucka","fucked","fucker","fuckers","fuckhead","fuckheads","fuckin","fucking","fuckings","fuckingshitmotherfucker","fuckme","fucks","fuckwhit","fuckwit","fudge packer","fudgepacker","fuk","fuker","fukker","fukkin","fuks","fukwhit","fukwit","fux","fux0r","f_u_c_k","gangbang","gangbanged","gangbangs","gaylord","gaysex","goatse","god-dam","god-damned","goddamn","goddamned","hardcoresex","hell","heshe","hoar","hoare","hoer","homo","hore","horniest","horny","hotsex","jack-off","jackoff","jap","jerk-off","jism","jiz","jizm","jizz","kawk","knob","knobead","knobed","knobend","knobhead","knobjocky","knobjokey","kock","kondum","kondums","kum","kummer","kumming","kums","kunilingus","l3i+ch","l3itch","labia","lmfao","lust","lusting","m0f0","m0fo","m45terbate","ma5terb8","ma5terbate","masochist","master-bate","masterb8","masterbat*","masterbat3","masterbate","masterbation","masterbations","masturbate","mo-fo","mof0","mofo","mothafuck","mothafucka","mothafuckas","mothafuckaz","mothafucked","mothafucker","mothafuckers","mothafuckin","mothafucking","mothafuckings","mothafucks","mother fucker","motherfuck","motherfucked","motherfucker","motherfuckers","motherfuckin","motherfucking","motherfuckings","motherfuckka","motherfucks","muff","mutha","muthafecker","muthafuckker","muther","mutherfucker","n1gga","n1gger","nazi","nigg3r","nigg4h","nigga","niggah","niggas","niggaz","nigger","niggers","nob","nob jokey","nobhead","nobjocky","nobjokey","numbnuts","nutsack","orgasim","orgasims","orgasm","orgasms","p0rn","pawn","pecker","penis","penisfucker","phonesex","phuck","phuk","phuked","phuking","phukked","phukking","phuks","phuq","pigfucker","pimpis","piss","pissed","pisser","pissers","pisses","pissflaps","pissin","pissing","pissoff","poop","porn","porno","pornography","pornos","prick","pricks","pron","pube","pusse","pussi","pussies","pussy","pussys","rectum","retard","rimjaw","rimming","s hit","s.o.b.","sadist","schlong","screwing","scroat","scrote","scrotum","semen","sex","sh!+","sh!t","sh1t","shag","shagger","shaggin","shagging","shemale","shi+","shit","shitdick","shite","shited","shitey","shitfuck","shitfull","shithead","shiting","shitings","shits","shitted","shitter","shitters","shitting","shittings","shitty","skank","slut","sluts","smegma","smut","snatch","son-of-a-bitch","spac","spunk","s_h_i_t","t1tt1e5","t1tties","teets","teez","testical","testicle","tit","titfuck","tits","titt","tittie5","tittiefucker","titties","tittyfuck","tittywank","titwank","tosser","turd","tw4t","twat","twathead","twatty","twunt","twunter","v14gra","v1gra","vagina","viagra","vulva","w00se","wang","wank","wanker","wanky","whoar","whore","willies","willy","xrated","xxx","bollocks","child-fucker","Christ on a bike","Christ on a cracker","swear word","godsdamn","holy shit","Jesus","Jesus Christ","Jesus H. Christ","Jesus Harold Christ","Jesus wept","Jesus, Mary and Joseph","Judas Priest","shit ass","shitass","son of a bitch","son of a motherless goat","son of a whore","sweet Jesus","2g1c","2 girls 1 cup","acrotomophilia","alabama hot pocket","alaskan pipeline","anilingus","apeshit","arsehole","assmunch","auto erotic","autoerotic","babeland","baby batter","baby juice","ball gag","ball gravy","ball kicking","ball licking","ball sack","ball sucking","bangbros","bareback","barely legal","barenaked","bastardo","bastinado","bbw","bdsm","beaner","beaners","beaver cleaver","beaver lips","big black","big breasts","big knockers","big tits","bimbos","birdlock","black cock","blonde action","blonde on blonde action","blow your load","blue waffle","blumpkin","bondage","booty call","brown showers","brunette action","bukkake","bulldyke","bullet vibe","bullshit","bung hole","bunghole","busty","buttcheeks","camel toe","camgirl","camslut","camwhore","carpetmuncher","chocolate rosebuds","circlejerk","cleveland steamer","clover clamps","clusterfuck","coprolagnia","coprophilia","cornhole","coons","creampie","darkie","date rape","daterape","deep throat","deepthroat","dendrophilia","dingleberry","dingleberries","dirty pillows","dirty sanchez","doggie style","doggiestyle","doggy style","doggystyle","dog style","dolcett","domination","dominatrix","dommes","donkey punch","double dong","double penetration","dp action","dry hump","dvda","eat my ass","ecchi","erotic","erotism","escort","eunuch","fecal","felch","feltch","female squirting","femdom","figging","fingerbang","fingering","fisting","foot fetish","footjob","frotting","fuck buttons","fucktards","futanari","gang bang","gay sex","genitals","giant cock","girl on","girl on top","girls gone wild","goatcx","god damn","gokkun","golden shower","goodpoop","goo girl","goregasm","grope","group sex","g-spot","guro","hand job","handjob","hard core","hardcore","hentai","homoerotic","honkey","hooker","hot carl","hot chick","how to kill","how to murder","huge fat","humping","incest","intercourse","jack off","jail bait","jailbait","jelly donut","jerk off","jigaboo","jiggaboo","jiggerboo","juggs","kike","kinbaku","kinkster","kinky","knobbing","leather restraint","leather straight jacket","lemon party","lolita","lovemaking","make me come","male squirting","menage a trois","milf","missionary position","mound of venus","mr hands","muff diver","muffdiving","nambla","nawashi","negro","neonazi","nig nog","nimphomania","nipple","nipples","nsfw images","nude","nudity","nympho","nymphomania","octopussy","omorashi","one cup two girls","one guy one jar","orgy","paedophile","paki","panties","panty","pedobear","pedophile","pegging","phone sex","piece of shit","piss pig","pisspig","playboy","pleasure chest","pole smoker","ponyplay","poof","poon","poontang","punany","poop chute","poopchute","prince albert piercing","pthc","pubes","queaf","queef","quim","raghead","raging boner","rape","raping","rapist","reverse cowgirl","rimjob","rosy palm","rosy palm and her 5 sisters","rusty trombone","sadism","santorum","scat","scissoring","sexo","sexy","shaved beaver","shaved pussy","shibari","shitblimp","shota","shrimping","skeet","slanteye","s&m","snowballing","sodomize","sodomy","spic","splooge","splooge moose","spooge","spread legs","strap on","strapon","strappado","strip club","style doggy","suck","sucks","suicide girls","sultry women","swastika","swinger","tainted love","taste my","tea bagging","threesome","throating","tied up","tight white","titty","tongue in a","topless","towelhead","tranny","tribadism","tub girl","tubgirl","tushy","twink","twinkie","two girls one cup","undressing","upskirt","urethra play","urophilia","venus mound","vibrator","violet wand","vorarephilia","voyeur","wetback","wet dream","white power","wrapping men","wrinkled starfish","xx","yaoi","yellow showers","yiffy","zoophilia","a54","buttmunch","donkeypunch","fleshflute","asswipe","ho","bitchass","moo moo foo foo","trumped","assbag","assbandit","assbanger","assbite","assclown","asscock","asscracker","assface","assfuck","assgoblin","asshat","ass-hat","asshead","asshopper","ass-jabber","assjacker","asslick","asslicker","assmonkey","assmuncher","assnigger","asspirate","ass-pirate","assshit","assshole","asssucker","asswad","axwound","bampot","bitchtits","bitchy","bollox","brotherfucker","bumblefuck","butt plug","buttfucka","butt-pirate","buttfucker","chesticle","chinc","choad","chode","clitface","clitfuck","cockass","cockbite","cockburger","cockfucker","cockjockey","cockknoker","cockmaster","cockmongler","cockmongruel","cockmonkey","cocknose","cocknugget","cockshit","cocksmith","cocksmoke","cocksmoker","cocksniffer","cockwaffle","coochie","coochy","cooter","cracker","cumbubble","cumdumpster","cumguzzler","cumjockey","cumslut","cumtart","cunnie","cuntass","cuntface","cunthole","cuntrag","cuntslut","dago","deggo","dickbag","dickbeaters","dickface","dickfuck","dickfucker","dickhole","dickjuice","dickmilk","dickmonger","dicks","dickslap","dick-sneeze","dicksucker","dicksucking","dicktickler","dickwad","dickweasel","dickweed","dickwod","dike","dipshit","doochbag","dookie","douche","douchebag","douche-fag","douchewaffle","dumass","dumb ass","dumbass","dumbfuck","dumbshit","dumshit","fagbag","fagfucker","faggit","faggotcock","fagtard","flamer","fuckass","fuckbag","fuckboy","fuckbrain","fuckbutt","fuckbutter","fuckersucker","fuckface","fuckhole","fucknut","fucknutt","fuckoff","fuckstick","fucktard","fucktart","fuckup","fuckwad","fuckwitt","gay","gayass","gaybob","gaydo","gayfuck","gayfuckist","gaytard","gaywad","goddamnit","gooch","gook","gringo","guido","hard on","heeb","hoe","homodumbshit","jackass","jagoff","jerkass","jungle bunny","junglebunny","kooch","kootch","kraut","kunt","kyke","lameass","lardass","lesbian","lesbo","lezzie","mcfagget","mick","minge","muffdiver","munging","nigaboo","niglet","nut sack","panooch","peckerhead","penisbanger","penispuffer","pissed off","polesmoker","pollock","poonani","poonany","porch monkey","porchmonkey","punanny","punta","pussylicking","puto","queer","queerbait","queerhole","renob","ruski","sand nigger","sandnigger","shitbag","shitbagger","shitbrains","shitbreath","shitcanned","shitcunt","shitface","shitfaced","shithole","shithouse","shitspitter","shitstain","shittiest","shiz","shiznit","skullfuck","slutbag","smeg","spick","spook","suckass","tard","thundercunt","twatlips","twats","twatwaffle","unclefucker","vag","vajayjay","va-j-j","vjayjay","wankjob","whorebag","whoreface","wop","fuck you","piss off","dick head","bloody hell","crikey","rubbish","taking the piss","jerk","knob end","lmao","omg","wtf","bint","ginger","git","minger","munter","sod off","chinky","choc ice","gippo","golliwog","hun","iap","jock","nig-nog","pikey","polack","sambo","slope","spade","taff","wog","beaver","beef curtains","bloodclaat","clunge","flaps","gash","punani","batty boy","bender","bum boy","bumclat","bummer","chi-chi man","chick with a dick","fudge-packer","gender bender","he-she","lezza/lesbo","pansy","shirt lifter","cretin","cripple","div","looney","midget","mong","nutter","psycho","schizo","veqtable","window licker","fenian","kafir","prod","taig","yid","iberian slap","middle finger","two fingers with tongue","two fingers","nonce","prickteaser","rapey","slag","tart","coffin dodger","old bag","frenchify","bescumber","microphallus","coccydynia","ninnyhammer","buncombe","hircismus","corpulent","feist","fice","cacafuego","ass fuck","assfaces","assmucus","bang (one's) box","bastards","beef curtain","bitch tit","blow me","blow mud","blue waffle","blumpkin","bust a load","butt fuck","choade","chota bags","clit licker","clitty litter","cock pocket","cock snot","cocksuck","cocksucked","cocksuckers","cocksucks","cop some wood","cornhole","corp whore","cum chugger","cum dumpster","cum freak","cum guzzler","cumdump","cunt hair","cuntbag","cuntlick","cuntlicker","cuntlicking","cuntsicle","cunt-struck","cut rope","cyberfuck","cyberfucked","cyberfucking","dick hole","dick shy","dickheads","dirty Sanchez","eat a dick","eat hair pie","ejaculates","ejaculating","facial","faggots","fingerfuck","fingerfucked","fingerfucker","fingerfucking","fingerfucks","fist fuck","fistfucked","fistfucker","fistfuckers","fistfucking","fistfuckings","fistfucks","flog the log","fuc","fuck hole","fuck puppet","fuck trophy","fuck yo mama","fuck","fuck-ass","fuck-bitch","fuckedup","fuckme","fuckmeat","fucktoy","fukkers","fuq","gang-bang","gassy ass","god","ham flap","how to murdep","jackasses","jiz","jizm","kinky Jesus","kwif","LEN","mafugly","mothafucked","mothafucking","mother fucker","muff puff","need the dick","nut butter","pisses","pissin","pissoff","pussy fart","pussy palace","queaf","sandbar","sausage queen","shit fucker","shitheads","shitters","shittier","slope","slut bucket","smartass","smartasses","tit wank","tities","wiseass","wiseasses","boong","coonnass","darn","Breeder","Cocklump","Doublelift","Dumbcunt","Fuck off","Poopuncher","Sandler","cockeye","crotte","cus","foah","fucktwat","jaggi","kunja","pust","sanger","seks","zubb","zibbi"
        });
        public static bool testing = false;
        private RegistrationPractice.Classes.Globals.Constants constants;
        private LoggerWrapper loggerwrapper;
        private ManageURL manageURL;

        public ItemsController(Classes.ManageURL _manageUrl, Classes.Globals.Constants constants, LoggerWrapper loggerwrapper, ApplicationUserManager userManager)
        {

            if (System.Web.HttpContext.Current == null)
            {
                //testing
                System.Web.HttpContext.Current = new HttpContext(
                new HttpRequest("", "https://awolr.com", ""),
                 new HttpResponse(new StringWriter())
                );



            }
            this._userManager = userManager;
            this.loggerwrapper = loggerwrapper;
            this.constants = constants;
            this.manageURL = _manageUrl;
            loggerwrapper.testingmode = false;
        }

        public async Task<ActionResult> UserPosts()
        {

            string useremail = null;
            if (System.Web.HttpContext.Current.Session["UserEmail"] != null && System.Web.HttpContext.Current.Session["UserEmail"].ToString().Length > 0)
                useremail = System.Web.HttpContext.Current.Session["UserEmail"].ToString();
            else
            {
                var userid = User.Identity.GetUserId();
                ApplicationUserManager applicationUserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                useremail = await applicationUserManager.GetEmailAsync(userid);
            }

            var items = db.Items.Where(i => i.OwnerUserEmail == useremail && i.HideItem == false);
            return View(await items.ToListAsync());
        }



        // GET: Items
        [AllowAnonymous]
        [CheckURLParameters(6)]
        public async Task<ActionResult> CityIndex(string country, string province, string city, string posttypefilter, string cityindex, string search_or_post, FormCollection formcollection, RegistrationPractice.Classes.Globals.Constants constants, CityListing cityListing, int p = 1) ////candidate for dependancy injection
        {
            ViewBag.country = country;
            ViewBag.province = province;
            ViewBag.city = city;
            ViewBag.metadescription = "Have your items gone awolr? Winnipeg Lost Found & Found Stolen Classified. Post, Share, Communicate anonymously, Retrieve Your Items. Winnipeg's foremost online lost and found";
            string commadelimitedcity = ViewBag.city_province = this.manageURL.createcommaseperatedcity(city);

            if (posttypefilter != null)
                ViewBag.PostType = textInfo.ToTitleCase(posttypefilter);
            HttpCookie mycookie = new HttpCookie("returnurl");
            HttpContext.Response.Cookies.Add(mycookie);
            mycookie.Value = HttpContext.Request.RawUrl;
            if (search_or_post != null && search_or_post.ToLower() == "post")
                return View("Create");



            IQueryable<Item> items = null;
            if (posttypefilter != null)
            {

                if (!RegistrationPractice.Classes.Globals.Constants.posttypes.Contains(posttypefilter))
                {
                    ViewBag.Message = "Invalid Search Type";
                    return View("invalidcity");
                }


                posttypefilter = posttypefilter.ToLower();
                ViewBag.detailsview = true;

                var cityid = db.Locations.SingleOrDefault(lo => lo.Location_Country == commadelimitedcity).Id;
                var dbid = constants.Getdbidbyposttype(posttypefilter);
                items = (from si in db.Items.Include("PostType").Include("Category").Include("Location").Where(si => (si.PostTypeID == dbid && si.HideItem == false) && si.LocationID == cityid) select (Item)si);

                ViewBag.metadescription = String.Format("{0} {1} classifieds", city, posttypefilter);
                if (posttypefilter == "stolen")
                {
                    items = items.Include("PostType").Include("Category").Include("Location").Where(si => si.PostTypeID == constants.stolendbid);
                }
                if (posttypefilter == "lost")
                {
                    items = items.Include("PostType").Include("Category").Include("Location").Where(si => si.PostTypeID == constants.lostdbid);
                }
                if (posttypefilter == "found")
                {
                    items = items.Include("PostType").Include("Category").Include("Location").Where(si => si.PostTypeID == constants.founddbid);
                }
                search_or_post = formcollection["search_or_post"];
                if (search_or_post != null && search_or_post != String.Empty)
                {
                    items = items.Where(i => (i.Description.ToLower().Contains(search_or_post.ToLower()) || i.AdditionalNotes.ToLower().Contains(search_or_post.ToLower())));
                }

                string checkbox = formcollection["includecategoriescheckbox"];
                if (checkbox == "on")
                {
                    string categoryid = formcollection["CategoryID"];
                    if (categoryid != String.Empty && categoryid != null)
                    {
                        int categoryidint = Int32.Parse(categoryid);
                        {
                            items = items.Where(i => (i.CategoryID == categoryidint));
                        }
                    }
                }
                ViewBag.ItemCount = items.Count();
                //values needed to render the form for first load as well as subsequen ajax calls

                int itemsperpage = 12;
                int totalitems = items.Count();
                int totalimagescurrentpage = 0;
                if (formcollection["paging"] != null && formcollection["paging"] != String.Empty)
                {
                    try
                    {

                        p = System.Convert.ToInt32(formcollection["paging"]);


                    }
                    catch (Exception e)
                    {
                        loggerwrapper.PickAndExecuteLogging("cannot convert pagingvaluefromform to integer");

                    }
                }

                if ((itemsperpage * p) > totalitems)
                {
                    totalimagescurrentpage = totalitems;
                }
                else
                {
                    totalimagescurrentpage = itemsperpage;
                }
                int skip = (p - 1) * itemsperpage;


                items = items.OrderByDescending(item => item.CreationDate).Skip(skip).Take(totalimagescurrentpage);

                //------------------------- 
                //items needed to render _PostCards
                ViewBag.itemsperpage = itemsperpage;
                ViewBag.totalitems = totalitems;
                ViewBag.paging = p;
                ViewBag.CategoryID = this.GetCategorySelectList(posttypefilter.ToLower());
                //--------------------------
                ViewBag.detailsview = true;
                ViewBag.BrowsingUserId = (string)System.Web.HttpContext.Current.Session["UserId"];

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_PostCards", await items.ToListAsync());

                }
                else
                    return View(await items.ToListAsync());

            }
            ViewBag.detailsview = false; //because the url did not contain lost, found, or stolen
            return View();
        }

        [AllowAnonymous]
        public ViewResult Start()
        {

            return View();
        }

        [AllowAnonymous]
        public JsonResult LoadCities(CityListing cityListing, string countryname = "", string searchquery = "")
        {
            if (String.IsNullOrEmpty(searchquery) || String.IsNullOrWhiteSpace(searchquery))
            {
                return Json(new EmptyResult(), JsonRequestBehavior.AllowGet);
            }
            List<LocationListing> cities = null;
            loggerwrapper.PickAndExecuteLogging("got to loadcities");
            countryname = countryname.ToLower();
            List<string> regions = null;
            List<LocationListing> locationListings = null;
            List<Region_LocationListing> region_LocationListings = new List<Region_LocationListing>();
            if (countryname == "canada")
            {
                ViewBag.country = "Canada";
            }
            else
            {
                ViewBag.country = "USA";
            }


            cities = cityListing.GetCities(countryname, searchquery);


            return Json(cities, JsonRequestBehavior.AllowGet);

        }


        // GET: Items
        [AllowAnonymous]
        public ActionResult CountryIndex()
        {
            loggerwrapper.PickAndExecuteLogging("got to loadcities");

            return View();
        }

        // GET: Items/Details/5
        //[RequiresRouteValuesAttribute("id")]
        [AllowAnonymous]
        public async Task<ActionResult> Details(int? state)
        {

            string a = null;
            if (RouteData.Values["state"] != null)
            {
                a = RouteData.Values["state"].ToString();
            }

            if (state == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(state);
            if (item == null || item.HideItem == true)
            {
                return HttpNotFound();
            }
            ViewBag.BrowsingUserId = (string)System.Web.HttpContext.Current.Session["UserId"];
            string useremail = (string)System.Web.HttpContext.Current.Session["UserEmail"];
            if (item != null && useremail != null)
            {
                if (useremail != item.OwnerUserEmail)
                    item.Visits++;
            }

            db.Entry(item).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
                ViewBag.PostType = item.PostType;
                return View(item);
            }
            catch (Exception e)
            {
                loggerwrapper.PickAndExecuteLogging("Cannot save visit increase in details method");
                return View(item);
            }


        }

        private IEnumerable<SelectListItem> GetCategorySelectList(string posttypefilter, Item item = null)
        {
            int posttypeid = 1;
            switch (posttypefilter)
            {
                case "lost":
                    posttypeid = 1;
                    break;
                case "found":
                    posttypeid = 2;
                    break;
                case "stolen":
                    posttypeid = 3;
                    break;
                default:
                    loggerwrapper.PickAndExecuteLogging("Could Not Filter By posttype");
                    break;
            }



            var categorylist =
             db.Categories
            .Join(db.CategoryPostType,
            c => c.Id,
            cp => cp.CategoryID,
            (c, cp) => new { c, cp })
            .Where(z => z.cp.PostTypeID == posttypeid)
            .Select(res => res.c)
            .ToList();

            var a = categorylist[0].CategoryText;
            SelectList selectlist = null;
            if (item != null)
            {
                selectlist = new SelectList(categorylist, "Id", "CategoryText", item.CategoryText);
            }
            else
            {
                selectlist = new SelectList(categorylist, "Id", "CategoryText");
            }


            return selectlist;


        }

        // GET: Items/Create
        [CheckURLParameters(6)]

        public async Task<ActionResult> Create(string country, string province, string city, string posttypefilter, string action, RegistrationPractice.Classes.Globals.Constants constants) ////candidate for dependancy injection
        {
            Item item = new Item();
            try
            {
                string commadelimitedcity = ViewBag.city_province = this.manageURL.createcommaseperatedcity(city);
                ViewBag.Province = province;
                ViewBag.CategoryID = this.GetCategorySelectList(posttypefilter, item);
                posttypefilter = textInfo.ToTitleCase(posttypefilter);
                ViewBag.PostType = textInfo.ToTitleCase(posttypefilter);
                item.Country = country;
                item.LocationID = constants.GetCityPrimaryKey(commadelimitedcity);
                item.City = commadelimitedcity;
                switch (posttypefilter)
                {
                    case "Stolen":

                        item.PostTypeID = 3;
                        item.ItemReward = 0;
                        break;
                    case "Found":
                        item.PostTypeID = 2;
                        break;
                    case "Lost":
                        item.PostTypeID = 1;
                        break;
                }



                string useremail = string.Empty;
                string userid = string.Empty;
                if (Request != null) //case for live
                {

                    if (System.Web.HttpContext.Current.Session["UserId"] != null && System.Web.HttpContext.Current.Session["UserEmail"].ToString().Length > 0)
                        userid = System.Web.HttpContext.Current.Session["UserId"].ToString();
                    else
                    {
                        userid = User.Identity.GetUserId();
                        System.Web.HttpContext.Current.Session["UserId"] = userid;
                    }

                    if (System.Web.HttpContext.Current.Session["UserEmail"] != null && System.Web.HttpContext.Current.Session["UserEmail"].ToString().Length > 0)
                        useremail = System.Web.HttpContext.Current.Session["UserEmail"].ToString();



                    if (useremail == null)
                    {
                        loggerwrapper.PickAndExecuteLogging("useremail not defined");
                    }
                    if (userid == null)
                    {
                        loggerwrapper.PickAndExecuteLogging("userid not defined");
                    }

                }
                else
                {
                    //for testing
                    useremail = "allanrodkin@gmail.com";
                }

                item.UserId = userid;
                item.OwnerUserEmail = useremail;


                //
                item.EmailRelayAddress = "";
                item.CreationDate = System.DateTime.Now;
                item.Visits = 1;
                item.Returned = false;
                item.HideItem = false;

            }
            catch (Exception e)
            {
                loggerwrapper.PickAndExecuteLogging(e.ToString());
            }
            return View("Create", item);
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SerialNumber,Country,City,LocationID,Id,LostOrFoundItem,LostLocation,NoReward,ItemReward,Description,CategoryID,CreationDate,EmailRelayAddress,AdditionalNotes,Visits,Returned,OwnerUserEmail,imageURL,imageTitle,HideItem,PostTypeID,FoundDate,UserId")] Item item, HttpPostedFileBase files, FormCollection formcollection, IO_Operations io, RegistrationPractice.Classes.Globals.Constants constants)
        {
            try
            {

                string province = formcollection["province"];
                string posttypefilter = formcollection["posttypefilter"];
                string foundate = formcollection["FoundDate"];
                if (!item.City.Contains(","))
                {
                    ViewBag.city_province = this.manageURL.createcommaseperatedcity(item.City);
                }


                if ((System.DateTime.Now - item.FoundDate).Days < 500)
                    ViewBag.RemoveDatePlaceholder = item.FoundDate.ToShortDateString();

                bool textContainsProfanity1 = (item.Description != null) && pf.ValidateTextContainsProfanity(item.Description);
                bool textContainsProfanity2 = (item.AdditionalNotes != null) && pf.ValidateTextContainsProfanity(item.AdditionalNotes);
                bool textContainsProfanity3 = (item.LostLocation != null) && pf.ValidateTextContainsProfanity(item.LostLocation);
                bool anyprofanity = textContainsProfanity1 || textContainsProfanity2 || textContainsProfanity3;
                if (textContainsProfanity1)
                {
                    ModelState.AddModelError(string.Empty, "Description contains profanity. Cannot submit.");
                }
                if (textContainsProfanity2)
                {
                    ModelState.AddModelError(string.Empty, "Additional Notes contains profanity. Cannot submit.");
                }
                if (textContainsProfanity3)
                {
                    ModelState.AddModelError(string.Empty, "Location contains profanity. Cannot submit.");
                }
                if (anyprofanity)
                {
                    goto imageproblem;
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if (files != null)
                        {
                            string imageUrl;
                            string result = io.SaveImage(files, out imageUrl);
                            item.imageURL = imageUrl;

                            if (result.Length > 0)
                            {
                                ModelState.AddModelError(string.Empty, result);
                                goto imageproblem;
                            }
                        }
                        db.Items.Add(item);
                        await db.SaveChangesAsync();
                    }
                    catch (Exception e)
                    {
                        loggerwrapper.PickAndExecuteLogging("item cannot be saved: " + e.ToString());
                    }




                    string route = string.Format("{0}/{1}/cityindex/{2}/{3}", item.Country, province, item.City, posttypefilter);
                    return RedirectToAction(route);

                }
                imageproblem:

                ViewBag.CategoryID = this.GetCategorySelectList(posttypefilter, item);
                //ViewBag.city_province = string.Format("{0},{1}", item.City, province);

                ViewBag.Province = province;

                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                posttypefilter = textInfo.ToTitleCase(posttypefilter);

                ViewBag.PostType = posttypefilter;
            }
            catch (Exception e)
            {
                loggerwrapper.PickAndExecuteLogging(e.ToString());
            }

            return View(item);
        }

        // GET: Items/Edit/5

        public async Task<ActionResult> Edit(int? id, RegistrationPractice.Classes.Globals.Constants constant)
        {

            try
            {
                string useremail = (string)System.Web.HttpContext.Current.Session["UserEmail"];

                var itemlist = await (db.Items.Where(i => i.Id == id).Include("PostType").Include("Category").ToListAsync());
                Item item = itemlist[0];
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                item.PostType.PostTypeText = textInfo.ToTitleCase(item.PostType.PostTypeText);



                ApplicationUserManager applicationUserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                string userid = System.Web.HttpContext.Current.Session["UserId"].ToString();
                bool isAdmin = await applicationUserManager.IsInRoleAsync(userid, "admin");
                if ((item != null && useremail != null && useremail != item.OwnerUserEmail) && !isAdmin)
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

                //IEnumerable<Category> categorylist = constants.GetCategorySelectList(item.PostType.PostTypeText);
                ViewBag.CategoryID = this.GetCategorySelectList(item.PostType.PostTypeText, item);
                ViewBag.LocationID = new SelectList(db.Locations, "Id", "LocationText", item.LocationID);
                if (item.imageURL != null) ViewBag.ImageUrl = item.imageURL;
                return View(item);
            }
            catch (Exception e)
            {
                loggerwrapper.PickAndExecuteLogging("cannot edit item");
                return View("start");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit([Bind(Include = "SerialNumber,UserId,City,Country,LostLocation,Id,LostOrFoundItem,NoReward,ItemReward,Description,LocationID,CategoryID,CreationDate,EmailRelayAddress,AdditionalNotes,Visits,Returned,OwnerUserEmail,imageURL,imageTitle,HideItem, PostTypeId")] Item item, HttpPostedFileBase files, FormCollection formcollection, IO_Operations io, RegistrationPractice.Classes.Globals.Constants constants)
        {

            //allan rodkin image code
            string updatetoimageurl = formcollection["UpdatedActionsFileUpload"];
            if (updatetoimageurl == "Delete")
            {
                item.imageURL = null;
            }


            bool textContainsProfanity1 = (item.Description != null) && pf.ValidateTextContainsProfanity(item.Description);
            bool textContainsProfanity2 = (item.AdditionalNotes != null) && pf.ValidateTextContainsProfanity(item.AdditionalNotes);
            bool textContainsProfanity3 = (item.LostLocation != null) && pf.ValidateTextContainsProfanity(item.LostLocation);
            bool anyprofanity = textContainsProfanity1 || textContainsProfanity2 || textContainsProfanity3;
            if (textContainsProfanity1)
            {
                ModelState.AddModelError(string.Empty, "Description contains profanity. Cannot submit.");
            }
            if (textContainsProfanity2)
            {
                ModelState.AddModelError(string.Empty, "Additional Notes contains profanity. Cannot submit.");
            }
            if (textContainsProfanity3)
            {
                ModelState.AddModelError(string.Empty, "Location contains profanity. Cannot submit.");
            }
            if (anyprofanity)
            {
                goto imageproblem;
            }

            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;

                try
                {

                    if (files != null)
                    {
                        var saveditem = db.Items.Where(i => i.Id == item.Id).ToList()[0];
                        bool success = io.DeleteImage(saveditem.imageURL);
                        string imageUrl;
                        string result = io.SaveImage(files, out imageUrl);
                        item.imageURL = imageUrl;

                        if (result.Length > 0)
                        {
                            ModelState.AddModelError(string.Empty, result);
                            goto imageproblem;
                        }
                    }

                    await db.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    loggerwrapper.PickAndExecuteLogging("item cannot be saved: " + e.ToString());

                }
                return RedirectToAction("UserPosts");
            }
            imageproblem:
            //allan rodkin
            item.PostType = new PostType();
            item.PostType.PostTypeText = db.PostTypes.SingleOrDefault(pt => pt.Id == item.PostTypeID).PostTypeText;
            //allan rodkin
            item.Category = new Category();
            string categorytext = db.Categories.SingleOrDefault(pt => pt.Id == item.CategoryID).CategoryText;

            //IEnumerable<Category> categorylist = constants.GetCategorySelectList(categorytext);


            ViewBag.CategoryID = new SelectList(categorytext, "Id", "CategoryText", item.CategoryID);
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "LocationText", item.LocationID);
            ViewBag.PostTypeID = new SelectList(db.PostTypes, "Id", "PostTypeText", item.PostTypeID);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Deleted(int? id)
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Report(int? id, string returnUrl)
        {
            ViewBag.PostInfo = String.Format("https://awolr.com/Items/Details?state=" + id);

            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> ProcessReport(FormCollection formcollection)
        {
            string body = formcollection["postinfo"];
            string reason = formcollection["message"];
            string returnUrl = formcollection["returnurl"];
            body = body + "\n\n" + reason;
            if (!this.IsCaptchaValid(""))
            {
                ModelState.AddModelError("captchavalidation", "captcha data incorrect");
                return View("Report");
            }
            string email = System.Configuration.ConfigurationManager.AppSettings["email"];
            string password = System.Configuration.ConfigurationManager.AppSettings["emailpassword"];
            string server = System.Configuration.ConfigurationManager.AppSettings["emailserver"];
            string emailport = System.Configuration.ConfigurationManager.AppSettings["emailport"];
            int port = Int32.Parse(emailport);
            try
            {

                //email = "admin@awolr.com";
                //password = "passWord321$";

                var client = new SmtpClient(server, port)
                {

                    Credentials = new NetworkCredential(email, password),
                    EnableSsl = true
                };


                await client.SendMailAsync("admin@awolr.com", "contact@awolr.com", "Post Report", body);
                int ampcharacter = returnUrl.IndexOf("&");
                returnUrl = returnUrl.Substring(0, ampcharacter);
                return Redirect(returnUrl);
            }
            catch (Exception e)
            {
                loggerwrapper.PickAndExecuteLogging("Could not report posting. Error " + e.ToString());
                int ampcharacter = returnUrl.IndexOf("&");
                returnUrl = returnUrl.Substring(0, ampcharacter);
                return Redirect(returnUrl);
            }
        }


        public async Task<ActionResult> Stats()
        {
            Totals totals = db.Totals.FirstOrDefault();
            if (totals != null)
            {
                TempData["Message"] = String.Format("Lost:{0} Found:{1} Stolen:{2}", totals.Lost.ToString(),
                    totals.Found.ToString(), totals.Stolen.ToString());

            }
            else
            {
                TempData["Message"] = "There is data";
            }
            return View();

        }

        [HttpPost]
        public async Task<ActionResult> Deleted(FormCollection formcollection)
        {
            if (formcollection["nextaction"].ToString() != "close")
            {

                try
                {

                    string posttype = TempData["PostType"].ToString();
                    string currentuser = TempData["CurrentUser"].ToString();
                    string itemuser = TempData["ItemUser"].ToString();
                    if (posttype == null || currentuser == null || itemuser == null)
                        return RedirectToAction("Start");
                    string response = formcollection["deleted"];
                    ApplicationUserManager applicationUserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    bool isAdmin = false;
                    try
                    {
                        isAdmin = await applicationUserManager.IsInRoleAsync(currentuser, "admin");
                    }
                    catch (Exception e)
                    {
                        loggerwrapper.PickAndExecuteLogging("Deleted - could not check role");
                    }

                    string collectstats = System.Configuration.ConfigurationManager.AppSettings["collectstats"];

                    if (collectstats == "true" && response.ToLower().Contains("awo") && posttype != null && (currentuser == itemuser || isAdmin))
                    {
                        Totals totals = new Totals();
                        totals = db.Totals.FirstOrDefault();

                        double stolen = 0, lost = 0, found = 0;
                        switch (posttype.ToLower())
                        {
                            case "stolen":
                                stolen++;
                                break;
                            case "lost":
                                lost++;
                                break;
                            case "found":
                                found++;
                                break;
                            default:
                                lost++;
                                break;
                        }
                        if (totals == null)
                        {
                            Totals totals2 = new Totals { Lost = lost, Found = found, Stolen = stolen };
                            db.Totals.Add(totals2);
                        }
                        else
                        {
                            db.Entry(totals).State = EntityState.Modified;
                            totals.Lost += lost;
                            totals.Found += found;
                            totals.Stolen += stolen;
                        }
                        await db.SaveChangesAsync();
                    }
                }
                catch (Exception e)
                {
                    loggerwrapper.PickAndExecuteLogging("Cannot load deleted feedback form");
                }
            }

            //int a = (int)totals.Lost;
            //int b = (int)totals.Stolen;
            //int c = (int)totals.Found;


            return RedirectToAction("Start");
        }






        public async Task<ActionResult> Permission()
        {
            return View();
        }


        public async Task<ActionResult> Delete(int? id)
        {
            string useremail = (string)System.Web.HttpContext.Current.Session["UserEmail"];

            Item item = await db.Items.FindAsync(id);
            TempData["PostType"] = item.PostType.PostTypeText;
            TempData["CurrentUser"] = useremail;
            TempData["ItemUser"] = item.OwnerUserEmail;
            ApplicationUserManager applicationUserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            string userid = System.Web.HttpContext.Current.Session["UserId"].ToString();
            bool isAdmin = false;
            try
            {
                isAdmin = await applicationUserManager.IsInRoleAsync(userid, "admin");
            }
            catch (Exception e)
            {

            }
            if ((item != null && useremail != null && useremail != item.OwnerUserEmail) && !isAdmin)
            {
                TempData["Message"] = "You do not have permission to modify this post.";
                return RedirectToAction("Permission", "Items", null);
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
        public async Task<ActionResult> DeleteConfirmed(int? id, IO_Operations io)
        {
            try
            {
                EmailsDbContext dbemail = new EmailsDbContext();
                EmailRecipients emailRecipients = new EmailRecipients();

                Item item = await db.Items.FindAsync(id);
                //db.Entry(item).State = EntityState.Modified;
                try
                {
                    //item.HideItem = true;
                    db.Items.Remove(item);
                    await db.SaveChangesAsync();
                    io.DeleteImage(item.imageURL);

                }
                catch (Exception e)
                {
                    loggerwrapper.PickAndExecuteLogging("Cannot delete item:");
                }

                try
                {
                    emailRecipients = dbemail.EmailRecipients.Where(i => i.IdItem == item.Id).FirstOrDefault();
                    if (emailRecipients != null)
                    {
                        dbemail.EmailRecipients.Remove(emailRecipients);
                        await dbemail.SaveChangesAsync();
                    }
                }
                catch (Exception e)
                {
                    loggerwrapper.PickAndExecuteLogging("Cannot delete emailrecipient:");

                }

                ViewBag.DeletedItem = item.Id.ToString();
                return RedirectToAction("Deleted");

                //return RedirectToAction("UserPosts");
            }
            catch (Exception e)
            {
                ViewBag.Message = "Item could not be deleted at this time";
                loggerwrapper.PickAndExecuteLogging("Delete failed for item.id" + id);
                return View("Invalidcity");
            }

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
