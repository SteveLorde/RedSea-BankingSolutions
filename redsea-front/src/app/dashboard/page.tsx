"use client";

import { useGlobalContext } from "@/services/stateManagement/contexts/globalContext";

export default function Page() {
  const {} = useGlobalContext();

  function switchToDashboardTab() {
    switch (activeDashboardType) {
      case banking:
        globalContext.setActiveDashboardTab(0);
        break;
      case invest:
        globalContext.setActiveDashboardTab(1);
        break;
    }
  }

  return <section>{activeTab}</section>;
}
