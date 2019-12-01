
CREATE TABLE public.categoria
(
    categoriaid integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    nombre character varying COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT categoria_pkey PRIMARY KEY (categoriaid)
)

CREATE TABLE public.jornada
(
    jornadaid integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    nombre character varying COLLATE pg_catalog."default",
    CONSTRAINT jornada_pkey PRIMARY KEY (jornadaid)
)

CREATE TABLE public.lugar
(
    lugarid integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    nombre character varying COLLATE pg_catalog."default",
    lugar character varying COLLATE pg_catalog."default",
    foto character varying COLLATE pg_catalog."default",
    horaentrada date,
    horacierre date,
    CONSTRAINT lugar_pkey PRIMARY KEY (lugarid)
)

CREATE TABLE public.usuario
(
    usuarioid integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    nombre character varying COLLATE pg_catalog."default" NOT NULL,
    clave character varying COLLATE pg_catalog."default" NOT NULL,
    tipo integer NOT NULL,
    CONSTRAINT usuario_pkey PRIMARY KEY (usuarioid)
)


CREATE TABLE public.itinerario_encabezado
(
    itinierarioid integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    fechainicio date,
    fechafinal integer,
    nombre character varying COLLATE pg_catalog."default",
    lugarid integer,
    CONSTRAINT itinerario_encabezado_pkey PRIMARY KEY (itinierarioid)
)


CREATE TABLE public.itinerario_detalle
(
    itinerario_detalleid integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    itinierarioid integer NOT NULL,
    actividadid integer NOT NULL,
    prioridad integer,
    CONSTRAINT itinerario_detalle_pkey PRIMARY KEY (itinerario_detalleid),
    CONSTRAINT fk_actividadid FOREIGN KEY (actividadid)
        REFERENCES public.actividades (actividadid) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT fk_itinierarioid FOREIGN KEY (itinierarioid)
        REFERENCES public.itinerario_encabezado (itinierarioid) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

CREATE TABLE public.actividades
(
    actividadid integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    nombre character varying COLLATE pg_catalog."default" NOT NULL,
    description character varying COLLATE pg_catalog."default" NOT NULL,
    horario character varying COLLATE pg_catalog."default",
    lugarid integer NOT NULL,
    categoriaid integer NOT NULL,
    jornadaid integer NOT NULL,
    duracion date,
    CONSTRAINT actividades_pkey PRIMARY KEY (actividadid),
    CONSTRAINT fk_categoriaid FOREIGN KEY (categoriaid)
        REFERENCES public.categoria (categoriaid) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT fk_jornadaid FOREIGN KEY (jornadaid)
        REFERENCES public.jornada (jornadaid) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT fk_lugarid FOREIGN KEY (lugarid)
        REFERENCES public.lugar (lugarid) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

