create table lugar(
	lugarid int generated always as identity not null primary key,
	nombre varchar
);

create table jornada (
	jornadaid int generated always as identity not null primary key,
	nombre varchar
);

create table categoria (
	categoriaid int generated always as identity not null primary key,
	nombre varchar not null
);

create table usuario(
	usuarioid int generated always as identity not null primary key,
	nombre varchar not null,
	clave varchar not null,
	tipo int not null
);

create table preferencia (
	prefeenciaid int generated always as identity not null primary key,
	usuarioid int not null,
	lugarid int not null,
	categoriaid int not null,
	jornadaid int not null
);

alter table preferencia add constraint fk_usuarioid
foreign key (usuarioid) references usuario(usuarioid);

alter table preferencia add constraint fk_lugarid
foreign key (lugarid) references lugar(lugarid);

alter table preferencia add constraint fk_categoriaid
foreign key (categoriaid) references categoria(categoriaid);

alter table preferencia add constraint fk_jornadaid
foreign key (jornadaid) references jornada(jornadaid);

create table actividades (
	actividadid int generated always as identity not null primary key,
	nombre varchar not null,
	description varchar not null,
	horario varchar,
	lugarid int not null,
	categoriaid int not null,
	jornadaid int not null
)

alter table actividades add constraint fk_lugarid
foreign key (lugarid) references lugar(lugarid);

alter table actividades add constraint fk_categoriaid
foreign key (categoriaid) references categoria(categoriaid);

alter table actividades add constraint fk_jornadaid
foreign key (jornadaid) references jornada(jornadaid);

create table seleccion (
	seleccionid int generated always as identity not null primary key,
	actividadid int not null,
	prefeenciaid int not null,
	prioridad int not null
)

alter table seleccion add constraint fk_actividadid
foreign key (actividadid) references actividades(actividadid);

alter table seleccion add constraint fk_prefeenciaid
foreign key (prefeenciaid) references preferencia(prefeenciaid);

create table itinerario_encabezado (
	itinierarioid int generated always as identity not null primary key,
	prefeenciaid int not null
)

alter table itinerario_encabezado add constraint fk_prefeenciaid
foreign key (prefeenciaid) references preferencia(prefeenciaid);

create table itinerario_detalle (
	itinerario_detalleid int generated always as identity not null primary key,
	itinierarioid int not null,
	actividadid int not null
)

alter table itinerario_detalle add constraint fk_itinierarioid
foreign key (itinierarioid) references itinerario_encabezado(itinierarioid);

alter table itinerario_detalle add constraint fk_actividadid
foreign key (actividadid) references actividades(actividadid);

