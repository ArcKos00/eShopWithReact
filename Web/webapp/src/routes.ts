import About from './pages/About';
import Home from './pages/Home';
import User from './pages/Artefact';
import Users from './pages/Artefacts';
import Login from './pages/Login';
import Settings from './pages/Settings'
import { Route } from './interfaces/route';

export const routes: Array<Route> = [
    {
        place: 'NavBar',
        key: 'home-route',
        title: 'Home',
        path: '/',
        enabled: true,
        component: Home
    },
    {
        place: 'NavBar',
        key: 'about-route',
        title: 'About',
        path: '/about',
        enabled: true,
        component: About
    },
    {
        place: 'NavBar',
        key: 'users-route',
        title: 'Users',
        path: '/users',
        enabled: true,
        component: Users
    },
    {
        place: 'NavBar',
        key: 'user-route',
        title: 'User',
        path: '/user/:id',
        enabled: false,
        component: User
    },
    {
        place: 'NavBar',
        key: 'login-user',
        title:'Login',
        path:'/login',
        enabled: false,
        component: Login
    },
    {
        place: 'UserMenu',
        key: 'info-user',
        title: 'User Info',
        path: 'user/:id',
        enabled: false,
        component: User
    },
    {
        place: 'UserMenu',
        key: 'user',
        title: 'User Settings',
        path: '/userSettings',
        enabled: true,
        component: Settings
    }
] 