import React from 'react';
import { useNavigate } from 'react-router-dom';

function UserHeader() {
    const navigator = useNavigate();

    return (
        <header className="bg-gradient-to-b from-black to-violet-900 text-white shadow-lg">
            <div className="container  px-4 py-4 flex ">
                <div className="flex items-center space-x-4">
                   
                </div>
                <nav className="flex space-x-4 flex-wrap justify-center sm:justify-start">
                    <Button
                        onClick={() => navigator('/userDashboard')}
                        label="Dashboard"
                    />
                    <Button
                        onClick={() => navigator('/user/history')}
                        label="History"
                    />
                    <Button
                        onClick={() => navigator('/user/subscription')}
                        label="Subscription"
                    />
                    <Button
                        onClick={() => navigator('/user/search')}
                        label="Search"
                    />
                    <button
                        onClick={() => navigator('/logout')}
                        className="px-4 py-2 bg-red-600 hover:bg-red-500 text-white font-semibold rounded-lg shadow-md transition duration-200 mt-2 sm:mt-0"
                    >
                        Logout
                    </button>
                </nav>
            </div>
        </header>
    );
}

function Button({ onClick, label }) {
    return (
        <button
            onClick={onClick}
            className="px-4 py-2 bg-gradient-to-r from-violet-700 to-violet-600 hover:from-violet-600 hover:to-violet-500 text-white font-semibold rounded-lg shadow-md transition duration-300 transform hover:scale-105 mb-2 sm:mb-0"
        >
            {label}
        </button>
    );
}

export default UserHeader;
