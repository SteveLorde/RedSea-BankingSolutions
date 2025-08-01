"use client";

import { createContext, useContext, useState } from "react";

interface sidebarNavigationContextType {
  active: number;
  ChangeActiveDashboardTab: (tab: number) => void;
}

const GlobalContext = createContext<sidebarNavigationContextType>({
  activeDashboardTab: 0,
  ChangeActiveDashboardTab: () => {},
});

export function useGlobalContext() {
  const context = useContext(GlobalContext);
  return context;
}

export function GlobalContextProvider({ children }: { children: React.ReactNode }) {
  const [activeDashboardTab, setActiveDashboardTab] = useState<number>(0);

  function ChangeActiveSubboard(subboardName: string) {
    // sear
  }

  return (
    <GlobalContext.Provider value={{ activeDashboardTab, ChangeActiveDashboardTab }}>
      {children}
    </GlobalContext.Provider>
  );
}
