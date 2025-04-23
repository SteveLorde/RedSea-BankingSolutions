'use client'

import {useState} from "react";
import DashboardBanking from "@/app/dashboard/_banking/main";
import DashboardInvesting from "@/app/dashboard/_investing/main";

export default function Page() {
    const [activeDashboardType, setActiveDashboardType] = useState<number>(0);
    const [activeTab, setActiveTab] = useState<React.ReactElement>();

    function switchToDashboardTab() {
        switch (activeDashboardType) {
            case 0 :
                setActiveTab(<DashboardBanking/>)
                break
            case 1 :
                setActiveTab(<DashboardInvesting/>)
                break
        }
    }

    return (
        <section>
            {activeTab}
        </section>
    )
}