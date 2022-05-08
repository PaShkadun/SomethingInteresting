<script>
import { UserManager, WebStorageStateStore, User } from 'oidc-client';
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class AuthService {
    userManager;
 
    constructor() {
        const STS_DOMAIN = 'https://localhost:5001/';
 
        const settings = {
            authority: "https://localhost:5001",
            client_id: "js",
            redirect_uri: "http://localhost:8080/callback.html",
            response_type: "code",
            scope: "openid profile",
            post_logout_redirect_uri : "http://localhost:8080/",
        };
 
        this.userManager = new UserManager(settings);
    }
 
    getUser() {
        return this.userManager.getUser()
    }
 
    login() {
        return this.userManager.signinRedirect()
    }
 
    logout() {
        return this.userManager.signoutRedirect();
    }
 
    getAccessToken() {
        return this.userManager.getUser().then((data) => {
            return data.access_token;
        });
    }
}
</script>