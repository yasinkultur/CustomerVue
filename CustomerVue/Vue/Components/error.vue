<script type="text/template" id="error-template">
    <main>
        <div class="error-box">
            <h1>System Error</h1>
            <div class="message">
                <p>Sorry, something isn't working properly</p>
                <p><router-link to="/">Click here to go back</router-link></p>
            </div>
        </div>
    </main>
</script>

<script type="text/javascript">
    var VueComponents = VueComponents || {};

    VueComponents.Error = Vue.component('error',
    {
        template: '#error-template',
        props: [],
        data: function ()
        {
            return {
            };
        },
        mounted: function ()
        {
          
        }
    });
</script>