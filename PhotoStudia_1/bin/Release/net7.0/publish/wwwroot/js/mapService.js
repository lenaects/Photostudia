window.mapService = {
    drawGeoZones: async function (zones, apiKey) {
        const mapId = 'ekb-map';
        const mapElement = L.DomUtil.get(mapId);
        if (mapElement._leaflet_id) {
            mapElement._leaflet_id = null;
        }

        const map = L.map(mapId).setView([56.8389, 60.6057], 11);

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            maxZoom: 18,
            attribution: '© OpenStreetMap'
        }).addTo(map);

        const colors = ['#BEE3DB', '#A2D2FF', '#FFB4A2', '#CDB4DB'];

        zones.sort((a, b) => a.radius_from_km - b.radius_from_km);

        for (let i = 0; i < zones.length; i++) {
            const zone = zones[i];
            const outer = Math.min(Math.round(zone.radius_to_km * 1000), 15000);
            const inner = Math.round(zone.radius_from_km * 1000);

            const urlOuter = `https://api.geoapify.com/v1/isoline?lat=56.8389&lon=60.6057&type=distance&mode=walk&range=${outer}&apiKey=${apiKey}`;
            const urlInner = `https://api.geoapify.com/v1/isoline?lat=56.8389&lon=60.6057&type=distance&mode=walk&range=${inner}&apiKey=${apiKey}`;

            try {
                const outerRes = await fetch(urlOuter);
                const outerJson = await outerRes.json();

                if (outerJson.features?.length > 0) {
                    const outerPoly = outerJson.features[0];
                    let ring = outerPoly;

                    // ⛏️ Если это НЕ первая зона — вычитаем inner
                    if (zone.radius_from_km > 0) {
                        const innerRes = await fetch(urlInner);
                        const innerJson = await innerRes.json();

                        if (innerJson.features?.length > 0) {
                            const innerPoly = innerJson.features[0];
                            ring = turf.difference(outerPoly, innerPoly);
                        }
                    }

                    const geoLayer = L.geoJSON(ring, {
                        style: {
                            color: '#333',
                            fillColor: colors[i % colors.length],
                            fillOpacity: 0.2,
                            weight: 1.5
                        }
                    }).addTo(map);

                    geoLayer.bindTooltip(`${zone.name}<br>Цена: ${zone.price} ₽`, {
                        sticky: true,
                        direction: 'top'
                    });
                }
            } catch (e) {
                console.error("❌ Ошибка при построении кольца:", e);
            }
        }
    }
};