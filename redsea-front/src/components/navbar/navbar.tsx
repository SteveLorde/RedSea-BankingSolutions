'use client';

import { useRef } from 'react';
import NotificationIcon from '@/assets/icons/Notification_icon.svg';
import AccountIcon from '@/assets/icons/account_icon.svg';
import LogoutIcon from '@/assets/icons/Logout_icon.svg';

export default function Navbar() {
  const clockRef = useRef(null);

  const notificationCount = 0;

  function navigateDashboardTabType(tabType: number) {}

  return (
    <div>
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
          <div className={''}>
            6+
            <p>{notificationCount}</p>
          </div>
          <NotificationIcon />
        </div>

        {/* Account Name */}
        <div>
          <AccountIcon />
          <p>{loggedAccount.Name}</p>
        </div>

        {/* Logout */}
        <div>
          <LogoutIcon />
          <p>Logout</p>
        </div>
      </div>
    </div>
  );
}
