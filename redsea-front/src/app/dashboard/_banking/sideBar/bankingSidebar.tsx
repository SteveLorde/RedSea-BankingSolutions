"use client";
import { AxiosInstance } from "axios";
import { useEffect, useState } from "react";

export async function BankingSidebar({ httpClient }: { httpClient: AxiosInstance }) {
  function NavigateSubboard(subboardTitle: string) {}

  const [sidebarNavItems, setSidebarNavItems] = useState<any>([]);

  useEffect(() => {
    const result = httpClient.get("/auth/login").then((res) => res.data);
    if (result !== null) {
      setSidebarNavItems(result);
    } else {
      console.log("no sidebar nav items");
    }
  }, [httpClient]);

  return (
    <div>
      <ul>
        {sidebarNavItems.map((sidebarNavItem) => (
          <li key={sidebarNavItem.title}>
            <button
              className={"sidebarNavItem"}
              onClick={() => NavigateSubboard(sidebarNavItem.title)}
            ></button>
          </li>
        ))}
      </ul>
    </div>
  );
}
