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

        const colors = ['#1a9850', '#fc8d59', '#d73027', '#4575b4'];

        for (let i = 0; i < zones.length; i++) {
            const zone = zones[i];
            const color = colors[i % colors.length];
            const range = Math.round(zone.radius_to_km * 1000); // обязательно округляем

            const url = `https://api.geoapify.com/v1/isoline?lat=56.8389&lon=60.6057&type=distance&mode=drive&range=${range}&apiKey=${apiKey}`;

            try {
                const response = await fetch(url);
                const result = await response.json();

                if (result.features && result.features.length > 0) {
                    const feature = result.features[0];

                    const geoLayer = L.geoJSON(feature, {
                        style: {
                            color: color,
                            fillColor: color,
                            fillOpacity: 0.3,
                            weight: 2
                        }
                    }).addTo(map);

                    geoLayer.eachLayer(layer => {
                        layer.bindTooltip(`${zone.name}<br>Цена: ${zone.price} ₽`, {
                            sticky: true
                        });
                    });
                }
            } catch (e) {
                console.error("❌ Ошибка запроса к Geoapify:", e);
            }
        }
    }
};