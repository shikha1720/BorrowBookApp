export interface SideNavItem {
    title: string;
    link: string;
}

export interface User {
    id: number;
    name: string;
    username: string;
    tokenAvailable: number;
    password: string;
}

export interface Book {
    id: number;
    name: string;
    rating : string;
    author: string;
    genre: string;
    isBookAvailable: boolean;
    description: string;
    lentByUserId: number;
    currentlyBorrowedByUserId: number;
}
