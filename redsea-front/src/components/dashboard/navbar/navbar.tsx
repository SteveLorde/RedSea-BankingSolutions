'use client'

import {useRef} from "react";
import {NotificationIcon} from "@/assets/icons/Notification Icon.svg"
import {AccountIcon} from "@/assets/icons/account icon.svg"
import {LogoutIcon} from "@/assets/icons/Logout Icon.svg"

export default function Navbar() {

    const clockRef = useRef(null);


    function navigateDashboardTabType(tabType: number) {

    }


    return <div>
        <div>
            <p ref={clockRef}></p>
        </div>

        <div>
            <button>Banking</button>
            <button>Investing</button>
        </div>

        <div>
            {/* Notifications */}
            <div>
                <div className={""}>
                    <p>{notificationCount}</p>
                </div>
                <NotificationIcon/>
            </div>

            {/* Account Name */}
            <div>
                <AccountIcon/>
                <p>{loggedAccount.Name}</p>
            </div>

            {/* Logout */}
            <div>
                <LogoutIcon/>
                <p>Logout</p>
            </div>
        </div>
    </div>
}