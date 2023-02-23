import { makeAutoObservable } from 'mobx';
import * as authApi from '../api/modules/auth';

class AuthStore {
    token = '';

    constructor() {
        makeAutoObservable(this);
    };

    async login(email: string, password: string) {
        const result = await authApi.login({ email, password });
        this.token = result.token;
    };

    async register(email: string, password: string) {
        return await authApi.register({ email, password });
    };

    logout() {
        this.token = '';
    };
};

export default AuthStore;