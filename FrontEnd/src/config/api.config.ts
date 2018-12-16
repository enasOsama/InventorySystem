import { environment } from "../environments/environment";

export const apiUrl = {
    "repository": {
        "base": environment.baseUrl
    },
    'userAccount': {
        'login': '/token',
        'register': 'authentication/Register'
    }
}