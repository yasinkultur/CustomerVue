<script type="text/template" id="site-app-template">
    <div>
        <header>
            <div class="header-inner">
                <div class="header-left">
                    <router-link to="/" class="logo"></router-link>
                </div>
                <div class="header-center">
                    Customers
                </div>
                <div class="header-right">
                    {{ userGreeting }}, {{ userGreetingName }}
                </div>
            </div>
        </header>

        <router-view @ajax-error="handleAjaxError" />

        <footer>
            <div class="footer-inner">
                Customers &mdash; Version {{ siteVersion }}
            </div>
        </footer>
    </div>
</script>

<script type="text/javascript">
    var VueApps = VueApps || {};
    var VueRouters = VueRouters || {};

    VueRouters.Site = new VueRouter(
    { 
        routes:  
        [
            {
                path: '/', 
                component: VueComponents.CustomerIndex 
            },
            {
                path: '/error',
                component: VueComponents.Error
            }
        ]
    });

    VueApps.Site = new Vue({
        router: VueRouters.Site,
        template: '#site-app-template',
        data:
        {
            userGreetingName: null,
            siteVersion: null,
            date: new Date()
        },
        computed:
        {
            userGreeting: function ()
            {
                var hours = this.date.getHours();

                if (hours < 12)
                {
                    return 'Good morning';
                }
                else if (hours < 18)
                {
                    return 'Good afternoon';
                }
                else
                {
                    return 'Good evening';
                }
            }
        },
        methods:
        {
            handleAjaxError: function (errorData)
            {
                console.error(JSON.stringify(errorData));
                
                if (errorData.status == 401)
                {
                    window.location.href = '/';
                    return;
                }

                if (errorData.readyState == 0 && errorData.status == 0)
                {
                    // Swallow errors if server has disappeared
                    return;
                }   
                
                this.$router.push({ path: '/error' })
            }
        },
        mounted: function ()
        {
            var that = this;
            
            setInterval(function() 
            { 
                that.date = new Date() 
            }, 60 * 1000);
        }
    });
</script>